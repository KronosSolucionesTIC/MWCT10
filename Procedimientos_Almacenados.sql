--Sentencia para crear procedimiento almacenado Login (Modificado)
CREATE PROCEDURE SP_inicio_Sesion2
@USER VARCHAR (20),
@PASS VARCHAR (20)
AS
SELECT USER_WEB,'true' FROM TB_CLIENT WHERE USER_WEB=@USER AND PWD_WEB=@PASS
GO 

--Sentencia para crear procedimiento almacenado Login (Modificado)
CREATE PROCEDURE SP_inicio_Sesion
@USER VARCHAR (20),
@PASS VARCHAR (20)
AS
SELECT USER_WEB,'true' FROM TB_CLIENT WHERE USER_WEB=@USER AND PWD_WEB=@PASS
GO 

--Sentencia para eliminar procedimiento SP_inicio_sesion
DROP PROCEDURE SP_inicio_sesion

--Sentencia para traer ID
CREATE PROCEDURE SP_id
@USER VARCHAR (20)
AS
SELECT ID_TBCLIENT FROM TB_CLIENT WHERE USER_WEB=@USER
GO 

--Sentencia para eliminar procedimiento SP_id
DROP PROCEDURE SP_id

--Sentencia para eliminar procedimiento SP_id
DROP PROCEDURE SP_acceder

--Sentencia para ingresar en log de login el acceso
CREATE PROCEDURE SP_acceder
@ID_USER INT,
@FECHA DATE
AS
INSERT INTO TB_LOGWEBSYS (ID_TBCLIENT,DATE_OPERATION) VALUES (@ID_USER,@FECHA);
GO 

--Sentencia para ingresar en log de login la salida
CREATE PROCEDURE SP_salida
@ID_USER INT,
@FECHA DATE
AS
INSERT INTO TB_LOGWEBSYS (ID_TBCLIENT,DATE_OPERATION) VALUES (@ID_USER,@FECHA);
GO 

--Sentencia para traer BLOQUEO
CREATE PROCEDURE SP_bloqueo
@USER VARCHAR (20)
AS
SELECT WEB_LOCKED FROM TB_CLIENT WHERE USER_WEB=@USER
GO 

--Sentencia para traer BLOQUEO
CREATE PROCEDURE SP_activo
@USER VARCHAR (20)
AS
SELECT WEB_ENABLE FROM TB_CLIENT WHERE USER_WEB=@USER
GO 

--Sentencia para eliminar SP_bloquear
DROP PROCEDURE SP_bloquear;

--Sentencia para traer BLOQUEO
CREATE PROCEDURE SP_bloquear
@USER VARCHAR (20)
AS
UPDATE TB_CLIENT set WEB_LOCKED=1 WHERE USER_WEB=@USER
GO 

--Sentencia para habilitar usuario
UPDATE TB_CLIENT set WEB_ENABLE=1 WHERE USER_WEB='Admin'

--Sentencia para traer CONSULTA INICIAL 
--Select con inner para DocEntrada, Serial y Grupo con condicional minimo
CREATE PROCEDURE SP_consulta_inicial
@ID_TBCLIENT INT
AS
SELECT DOC_ENTRY,NUM_SERIAL,NAME_GROUP,DATE_ENTRY,ID_TBACTYMTR,CASE ID_STATE
         WHEN '2' then 'No recibido en sitio'                        
         WHEN '0' THEN 'Precarga'
         WHEN '1' THEN 'Alistamiento inicial'
         WHEN '5' THEN 'Operacion en mesas'
         WHEN '9' THEN 'Revision de certificado'
         WHEN '11' THEN 'Etapa de salida'
         WHEN '12' THEN 'En tramite'
         WHEN '16' THEN 'Rechazo de recepcion'
         WHEN '2' THEN 'No recibido en sitio'
         ELSE 'No encontrado'
       end 
       AS ID_STATE
       FROM TB_GROUP
INNER JOIN (TB_DEVICES INNER JOIN TB_ACTY_MTR ON TB_DEVICES.ID_TBDEVICES = TB_ACTY_MTR.ID_TBDEVICES) 
ON TB_GROUP.ID_TBGROUP =  TB_DEVICES.ID_TBGROUP
WHERE DATEDIFF(day, DATE_ENTRY, GETDATE ( )) > 15 AND ID_TBCLIENT = @ID_TBCLIENT
GO 

--Sentencia para documentos entrada
SELECT DOC_ENTRY, NUM_SERIAL, NAME_GROUP FROM TB_GROUP 
INNER JOIN (TB_DEVICES INNER JOIN TB_ACTY_MTR ON TB_DEVICES.ID_TBDEVICES = TB_ACTY_MTR.ID_TBDEVICES) 
ON TB_GROUP.ID_TBGROUP =  TB_DEVICES.ID_TBGROUP
WHERE DATEDIFF(day, DATE_ENTRY, GETDATE ( )) > 15 AND ID_TBCLIENT = @ID_TBCLIENT;

--Sentencia para eliminar SP_consulta_inicial
DROP PROCEDURE SP_consulta_inicial;

--Sentencia para eliminar procedimiento SP_consulta_actualizar
DROP PROCEDURE SP_consulta_actualizar;

--Sentencia para CREAR procedimiento SP_consulta_actualizar
CREATE PROCEDURE SP_consulta_actualizar
@USUARIO INT,
@DOC_ENTRADA varchar(20),
@NUM_SERIAL varchar(20),
@GRUPO varchar(10),
@FECHAINI AS DATE,
@FECHAFIN AS DATE,
@ESTADO INT
AS
DECLARE @SQL_SENTENCIA VARCHAR(5000) = ''
DECLARE @FECINI VARCHAR(15) = LTRIM(RTRIM(CONVERT(CHAR, @FECHAINI)))
DECLARE @FECFIN VARCHAR(15) = LTRIM(RTRIM(CONVERT(CHAR, @FECHAFIN)))
DECLARE @condiciones varchar(5000)
SET @condiciones = ''

IF @DOC_ENTRADA != ''
	SELECT @condiciones =  @condiciones + ' AND DOC_ENTRY = ' + QUOTENAME(@DOC_ENTRADA,'''')
ELSE 
	SELECT @condiciones =  @condiciones

IF @NUM_SERIAL != ''
	SELECT @condiciones =  @condiciones + ' AND NUM_SERIAL = ' + QUOTENAME(@NUM_SERIAL,'''')
ELSE 
	SELECT @condiciones =  @condiciones

IF @GRUPO != ''
	SELECT @condiciones =  @condiciones + ' AND NAME_GROUP = ' + QUOTENAME(@GRUPO,'''')
ELSE 
	SELECT @condiciones =  @condiciones

IF @FECHAINI != ''
	SELECT @condiciones =  @condiciones + ' AND (DATE_ENTRY>='''+@FECINI+''' AND DATE_ENTRY<= '''+@FECFIN+''' )'
ELSE 
	SELECT @condiciones =  @condiciones

IF @ESTADO != ''
	SELECT @condiciones =  @condiciones + ' AND ID_STATE = ' + CONVERT(VARCHAR,@ESTADO)
ELSE 
	SELECT @condiciones =  @condiciones

SET @SQL_SENTENCIA = 'SELECT DOC_ENTRY,NUM_SERIAL,NAME_GROUP,DATE_ENTRY,ID_TBACTYMTR,CASE ID_STATE
         WHEN ''2'' then ''No recibido en sitio''                        
         WHEN ''0'' THEN ''Precarga''
         WHEN ''1'' THEN ''Alistamiento inicial''
         WHEN ''5'' THEN ''peracion en mesas''
         WHEN ''9'' THEN ''Revision de certificado''
         WHEN ''11'' THEN ''Etapa de salida''
         WHEN ''12'' THEN ''En tramite''
         WHEN ''16'' THEN ''Rechazo de recepcion''
         WHEN ''2'' THEN ''No recibido en sitio''
         ELSE ''No encontrado''
       end 
       AS ID_STATE FROM TB_GROUP
INNER JOIN (TB_DEVICES INNER JOIN TB_ACTY_MTR ON TB_DEVICES.ID_TBDEVICES = TB_ACTY_MTR.ID_TBDEVICES) 
ON TB_GROUP.ID_TBGROUP =  TB_DEVICES.ID_TBGROUP 
WHERE ID_TBCLIENT = ' + CONVERT(VARCHAR,@USUARIO) + @condiciones
EXEC (@SQL_SENTENCIA)
GO

--Sentencia para probar procedimiento SP_consulta_actualizar
EXEC SP_consulta_actualizar 3,'','2019-01-01','2019-04-12',2;

--Sentencia para modificar el case sensitive de la columba USER_WEB tabla TB_CLIENT
ALTER TABLE TB_CLIENT ALTER COLUMN USER_WEB  
            varchar(15)COLLATE Latin1_General_CS_AS NOT NULL;  
GO 

--Sentencia para modificar el case sensitive de la columba USER_WEB tabla TB_CLIENT
ALTER TABLE TB_CLIENT ALTER COLUMN PWD_WEB
            varchar(15)COLLATE Latin1_General_CS_AS NOT NULL;  
GO 

--Sentencia para cargar el filtro Documento de entrada
CREATE PROCEDURE SP_documentos_entrada
@ID_TBCLIENT INT
AS
SELECT DOC_ENTRY FROM TB_GROUP 
INNER JOIN (TB_DEVICES INNER JOIN TB_ACTY_MTR ON TB_DEVICES.ID_TBDEVICES = TB_ACTY_MTR.ID_TBDEVICES) 
ON TB_GROUP.ID_TBGROUP =  TB_DEVICES.ID_TBGROUP
WHERE DATEDIFF(day, DATE_ENTRY, GETDATE ( )) < 15 AND ID_TBCLIENT = @ID_TBCLIENT
GO 

--Sentencia para eliminar SP_documentos_entrada
DROP PROCEDURE SP_documentos_entrada;

--Sentencia para cargar el filtro Numero de serial
CREATE PROCEDURE SP_numero_serial
@ID_TBCLIENT INT
AS
SELECT NUM_SERIAL FROM TB_GROUP 
INNER JOIN (TB_DEVICES INNER JOIN TB_ACTY_MTR ON TB_DEVICES.ID_TBDEVICES = TB_ACTY_MTR.ID_TBDEVICES) 
ON TB_GROUP.ID_TBGROUP =  TB_DEVICES.ID_TBGROUP
WHERE DATEDIFF(day, DATE_ENTRY, GETDATE ( )) < 15 AND ID_TBCLIENT = @ID_TBCLIENT
GO 

--Sentencia para eliminar SP_numero_serial
DROP PROCEDURE SP_numero_serial

--Sentencia para cargar el filtro Grupo
CREATE PROCEDURE SP_grupo
@ID_TBCLIENT INT
AS
SELECT NAME_GROUP FROM TB_GROUP 
INNER JOIN (TB_DEVICES INNER JOIN TB_ACTY_MTR ON TB_DEVICES.ID_TBDEVICES = TB_ACTY_MTR.ID_TBDEVICES) 
ON TB_GROUP.ID_TBGROUP =  TB_DEVICES.ID_TBGROUP
WHERE DATEDIFF(day, DATE_ENTRY, GETDATE ( )) < 15 AND ID_TBCLIENT = @ID_TBCLIENT
GO 

--Sentencia para eliminar SP_numero_serial
DROP PROCEDURE SP_grupo

--Sentencia para cargar el filtro Marca
CREATE PROCEDURE SP_marca
AS
SELECT DISTINCT MARK FROM TB_GROUP
GO

--Sentencia para cargar el filtro 
CREATE PROCEDURE SP_modelo
@MARCA varchar(20)
AS
DECLARE @SQL_SENTENCIA VARCHAR(5000) = ''
DECLARE @condiciones varchar(5000)
SET @condiciones = ''

IF @MARCA != ''
    SELECT @condiciones =  @condiciones + ' WHERE MARK = ' + QUOTENAME(@MARCA,'''')
ELSE 
    SELECT @condiciones =  @condiciones

SET @SQL_SENTENCIA = 'SELECT DISTINCT NAME_MODEL FROM TB_GROUP' + @condiciones
EXEC (@SQL_SENTENCIA)
GO

DROP PROCEDURE SP_modelo;

EXEC SP_modelo '';

