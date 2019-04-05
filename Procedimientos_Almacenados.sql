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

--Sentencia para ingresar en log de login
CREATE PROCEDURE SP_acceder
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
CREATE PROCEDURE SP_consulta_inicial
AS
SELECT ID_TBACTYMTR,DOC_ENTRY,DATE_ENTRY, ID_STATE FROM TB_ACTY_MTR
GO 

--Sentencia para traer CONSULTA ACTUALIZAR
CREATE PROCEDURE SP_consulta_actualizar
@ESTADO INT
AS
SELECT ID_TBACTYMTR,DOC_ENTRY,DATE_ENTRY, ID_STATE FROM TB_ACTY_MTR WHERE ID_STATE = @ESTADO
GO 

--Sentencia para eliminar procedimiento SP_consulta_actualizar
DROP PROCEDURE SP_consulta_actualizar

--Sentencia para modificar el case sensitive de la columba USER_WEB tabla TB_CLIENT
ALTER TABLE TB_CLIENT ALTER COLUMN USER_WEB  
            varchar(15)COLLATE Latin1_General_CS_AS NOT NULL;  
GO 

--Sentencia para modificar el case sensitive de la columba USER_WEB tabla TB_CLIENT
ALTER TABLE TB_CLIENT ALTER COLUMN PWD_WEB
            varchar(15)COLLATE Latin1_General_CS_AS NOT NULL;  
GO 