CREATE DATABASE Cibertec_CL2_Maribel
GO

use Cibertec_CL2_Maribel
go


CREATE TABLE CARRERA(
	idCarrera int identity(1,1) primary key, 
	nombreCarrera varchar(255) not null
);

CREATE TABLE POSTULANTE (
	idPostulante int identity(1,1) primary key, 
	dniPostulante char(8) not null,
	nombresPostulante varchar(255) not null,
	apellidosPostulante varchar(255) not null,
	nombreColegio varchar(255) null, 
	anioEgreso int not null,
	idCarrera int not null, 
);


ALTER TABLE POSTULANTE
ADD CONSTRAINT FK_PostulanteCarrera
FOREIGN KEY (idCarrera) REFERENCES CARRERA(idCarrera);


/**Insertamos valores**/
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Arquitectura');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ciencias Fisicas');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ciencias Matemáticas');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingenieria Ambiental');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingenieria Civil');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Económica');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Electrica');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Electromecánica');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Electrónica');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Estadística');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Física');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Geologíca');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Industrial');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Mecatrónica');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Mecánica');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Metalúrgica');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Minas');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Naval');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Petroquímica');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Petróleo');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Química');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Sanitaria');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Sistemas');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Telecomunicaciones');
INSERT INTO CARRERA(nombreCarrera)
VALUES ('Ingeniería Textil');




INSERT INTO POSTULANTE(dniPostulante, nombresPostulante, apellidosPostulante,nombreColegio,
			anioEgreso,idCarrera )
VALUES (77033456, 'Victor Alberto', 'Maza Auccatinco', 'IEP SEMILLITAS DEL SABER', 2020, 5);

--select * from POSTULANTE


---- sp que lista Postulantes
CREATE OR ALTER PROCEDURE sp_GetPostulantes
AS
BEGIN
	SELECT P.idPostulante, P.dniPostulante, P.nombresPostulante, 
			P.apellidosPostulante, P.nombreColegio, P.anioEgreso, C.nombreCarrera
	FROM POSTULANTE P
	INNER JOIN CARRERA C ON C.idCarrera = P.idCarrera
END
GO

--EXEC sp_GetPostulantes

--- sp que lista las carreras
CREATE OR ALTER PROCEDURE sp_GetCarreras
AS
BEGIN
	SELECT C.idCarrera, C.nombreCarrera
	FROM CARRERA C
END
GO
--EXEC sp_GetCarreras


-- INSERT
CREATE OR ALTER PROCEDURE sp_InsertPostulante
	@prmDniPostulante char(8),
	@prmNombresPostulante varchar(255),
	@prmApellidosPostulante varchar(255),
	@prmNombreColegio varchar(255),
	@prmAnioEgreso int,
	@prmIdCarrera int
AS
BEGIN
	INSERT INTO POSTULANTE(dniPostulante, nombresPostulante, apellidosPostulante, nombreColegio, 
		anioEgreso, idCarrera)
	VALUES (@prmDniPostulante, @prmNombresPostulante, @prmApellidosPostulante, 
			@prmNombreColegio,@prmAnioEgreso, @prmIdCarrera)
END
GO

-- UPDATE
CREATE OR ALTER PROCEDURE sp_UpdatePostulante
	@prmIdPostulante int,
	@prmDniPostulante char(8),
	@prmNombresPostulante varchar(255),
	@prmApellidosPostulante varchar(255),
	@prmNombreColegio varchar(255),
	@prmAnioEgreso int,
	@prmIdCarrera int
AS
BEGIN

	UPDATE POSTULANTE
	SET 
		dniPostulante = @prmDniPostulante,
		nombresPostulante = @prmNombresPostulante,
		apellidosPostulante = @prmApellidosPostulante,
		nombreColegio = @prmNombreColegio,
		anioEgreso = @prmAnioEgreso,
		idCarrera = @prmIdCarrera
	WHERE idPostulante = @prmIdPostulante

END
GO

-- DELETE
CREATE OR ALTER PROCEDURE sp_DeletePostulante
	@prmIdPostulante int
AS
BEGIN
	DELETE FROM POSTULANTE WHERE idPostulante = @prmIdPostulante
END
GO