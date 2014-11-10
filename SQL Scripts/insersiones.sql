insert into Categoria values ('Bromatol�gicos')
insert into Categoria values ('Abono Org�nico')
insert into Categoria values ('Foliar')
insert into Categoria values ('Suelos')
insert into Categoria values ('Otros')

insert into Dato values('Boro', 'B')
insert into Dato values('Azufre', 'S')
insert into Dato values('Hidr�geno', 'H')
insert into Dato values('Nitr�geno', 'N')
insert into Dato values('Potasio', 'K')
insert into Dato values('F�sforo', 'P')
insert into Dato values('Magnesio', 'Mg')
insert into Dato values('Calcio', 'Ca')
insert into Dato values('Promedio', 'Pro')

insert into Analisis_Dato values(3,9)


INSERT INTO Analisis(Nombre, Costo, IdCategoria, Descripcion) VALUES ('Materia Seca', 2000, 1, null)
INSERT INTO Analisis(Nombre, Costo, IdCategoria, Descripcion) VALUES ('Nitr�geno Total', 6000, 1, 'desc')
INSERT INTO Analisis(Nombre, Costo, IdCategoria, Descripcion) VALUES ('Digestibilidad in vitro', 6200, 1, 'desc')
INSERT INTO Analisis(Nombre, Costo, IdCategoria, Descripcion) VALUES ('Fibra detergente neutro', 1, 5000, 'desc')
/*INSERT INTO Analisis(Nombre, Costo, IdCategoria, Descripcion) VALUES ('Fibra detergente �cido', 1, 5000, 'desc')
INSERT INTO Analisis(Nombre, Costo, IdCategoria, Descripcion) VALUES ('Cenizas', 1, 3500, 'desc')*/

INSERT INTO Analisis(Nombre, Costo, IdCategoria, Descripcion) VALUES ('Humedad Muestra H�meda', 1500, 2, null)
/*INSERT INTO Analisis(Nombre, Costo, IdCategoria, Descripcion) VALUES ('Nitr�geno Total', 2, 6000, 'desc')*/
INSERT INTO Analisis(Nombre, Costo, IdCategoria, Descripcion) VALUES ('Densidad de  Volumen', 1500, 2, 'desc')
INSERT INTO Analisis(Nombre, Costo, IdCategoria, Descripcion) VALUES ('Humedad Muestra Seca', 1500, 2, 'desc')
INSERT INTO Analisis(Nombre, Costo, IdCategoria, Descripcion) VALUES ('Materia Org�nica', 1500, 2, 'desc')
INSERT INTO Analisis(Nombre, Costo, IdCategoria, Descripcion) VALUES ('Qu�mico Completo', 1500, 2, 'desc')

insert into Persona values('Jorge','Rojas','Aragon�s','jeragones@gmail.com','12345','86758925','24601913',0,2,'jeragones',1)
insert into Persona values('Dany Sadrac','Luna','Baez','lunasadrac@gmail.com','12345','88979045','86889423',0,2,'lunas',1)
insert into Persona values('Jose Daniel','Berrocal','Ram�rez','jdbr1992@gmail.com','12345','89562314','24628914',0,2,'jdberrocal1',1)
insert into Persona values('Nixon Steven','Espinoza','Matamoros','nspinozam@gmail.com','12345','88956325','88952345',0,1,'nspinozam',1)
insert into Persona values('SUADMIN','SUADMIN','SUADMIN','SUADMIN@gmail.com','suadmin','88888888','88888888',0,0,'SUADMIN',1)

insert into Provincia(nombre) values('San Jose'); 
insert into Provincia(nombre) values('Alajuela'); 
insert into Provincia(nombre) values('Cartago'); 
insert into Provincia(nombre) values('Heredia'); 
insert into Provincia(nombre) values('Guanacaste'); 
insert into Provincia(nombre) values('Puntarenas'); 
insert into Provincia(nombre) values('Limon'); 

/* 01 */insert into Canton(ID_Provincia,nombre) values(1,'San Jose'); 
/* 02 */insert into Canton(ID_Provincia,nombre) values(1,'Escazu'); 
/* 03 */insert into Canton(ID_Provincia,nombre) values(1,'Desamparados'); 
/* 04 */insert into Canton(ID_Provincia,nombre) values(1,'Puriscal'); 
/* 05 */insert into Canton(ID_Provincia,nombre) values(1,'Aserri'); 
/* 06 */insert into Canton(ID_Provincia,nombre) values(1,'Mora'); 
/* 07 */insert into Canton(ID_Provincia,nombre) values(1,'Goicoechea'); 
/* 08 */insert into Canton(ID_Provincia,nombre) values(1,'Santa Ana'); 
/* 09 */insert into Canton(ID_Provincia,nombre) values(1,'Alajuelita'); 
/* 10 */insert into Canton(ID_Provincia,nombre) values(1,'Vasquez de Coronado'); 
/* 11 */insert into Canton(ID_Provincia,nombre) values(1,'Acosta'); 
/* 12 */insert into Canton(ID_Provincia,nombre) values(1,'Tibas'); 
/* 13 */insert into Canton(ID_Provincia,nombre) values(1,'Moravia'); 
/* 14 */insert into Canton(ID_Provincia,nombre) values(1,'Montes de Oca'); 
/* 15 */insert into Canton(ID_Provincia,nombre) values(1,'Turrubares'); 
/* 16 */insert into Canton(ID_Provincia,nombre) values(1,'Dota'); 
/* 17 */insert into Canton(ID_Provincia,nombre) values(1,'Curridabat'); 
/* 18 */insert into Canton(ID_Provincia,nombre) values(1,'Perez Zeledon'); 
/* 19 */insert into Canton(ID_Provincia,nombre) values(1,'Leon Cortez');

/* 20 */insert into Canton(ID_Provincia,nombre) values(2,'Alajuela'); 
/* 21 */insert into Canton(ID_Provincia,nombre) values(2,'San Ramon'); 
/* 22 */insert into Canton(ID_Provincia,nombre) values(2,'Grecia'); 
/* 23 */insert into Canton(ID_Provincia,nombre) values(2,'San Mateo'); 
/* 24 */insert into Canton(ID_Provincia,nombre) values(2,'Atenas'); 
/* 25 */insert into Canton(ID_Provincia,nombre) values(2,'Naranjo'); 
/* 26 */insert into Canton(ID_Provincia,nombre) values(2,'Palmares'); 
/* 27 */insert into Canton(ID_Provincia,nombre) values(2,'Poas'); 
/* 28 */insert into Canton(ID_Provincia,nombre) values(2,'Orotina'); 
/* 29 */insert into Canton(ID_Provincia,nombre) values(2,'San Carlos'); 
/* 30 */insert into Canton(ID_Provincia,nombre) values(2,'Alfaro Ruiz'); 
/* 31 */insert into Canton(ID_Provincia,nombre) values(2,'Valverde Vega'); 
/* 32 */insert into Canton(ID_Provincia,nombre) values(2,'Upala'); 
/* 33 */insert into Canton(ID_Provincia,nombre) values(2,'Los Chiles'); 
/* 34 */insert into Canton(ID_Provincia,nombre) values(2,'Guatuso');

/* 35 */insert into Canton(ID_Provincia,nombre) values(3,'Cartago'); 
/* 36 */insert into Canton(ID_Provincia,nombre) values(3,'Paraiso'); 
/* 37 */insert into Canton(ID_Provincia,nombre) values(3,'La Union'); 
/* 38 */insert into Canton(ID_Provincia,nombre) values(3,'Jimenez'); 
/* 39 */insert into Canton(ID_Provincia,nombre) values(3,'Turrialba'); 
/* 40 */insert into Canton(ID_Provincia,nombre) values(3,'Alvarado'); 
/* 41 */insert into Canton(ID_Provincia,nombre) values(3,'Oreamuno'); 
/* 42 */insert into Canton(ID_Provincia,nombre) values(3,'El Guarco');

/* 43 */insert into Canton(ID_Provincia,nombre) values(4,'Heredia'); 
/* 44 */insert into Canton(ID_Provincia,nombre) values(4,'Barva'); 
/* 45 */insert into Canton(ID_Provincia,nombre) values(4,'Santo Domingo'); 
/* 46 */insert into Canton(ID_Provincia,nombre) values(4,'Santa Barbara'); 
/* 47 */insert into Canton(ID_Provincia,nombre) values(4,'San Rafael'); 
/* 48 */insert into Canton(ID_Provincia,nombre) values(4,'San Isidro'); 
/* 49 */insert into Canton(ID_Provincia,nombre) values(4,'Belen'); 
/* 50 */insert into Canton(ID_Provincia,nombre) values(4,'Flores'); 
/* 51 */insert into Canton(ID_Provincia,nombre) values(4,'San Pablo'); 
/* 52 */insert into Canton(ID_Provincia,nombre) values(4,'Sarapiqui');

/* 53 */insert into Canton(ID_Provincia,nombre) values(5,'Liberia'); 
/* 54 */insert into Canton(ID_Provincia,nombre) values(5,'Nicoya'); 
/* 55 */insert into Canton(ID_Provincia,nombre) values(5,'Santa Cruz'); 
/* 56 */insert into Canton(ID_Provincia,nombre) values(5,'Bagaces'); 
/* 57 */insert into Canton(ID_Provincia,nombre) values(5,'Carrillo'); 
/* 58 */insert into Canton(ID_Provincia,nombre) values(5,'Ca�as'); 
/* 59 */insert into Canton(ID_Provincia,nombre) values(5,'Abangares'); 
/* 60 */insert into Canton(ID_Provincia,nombre) values(5,'Tilaran'); 
/* 61 */insert into Canton(ID_Provincia,nombre) values(5,'Nandayure'); 
/* 62 */insert into Canton(ID_Provincia,nombre) values(5,'La Cruz'); 
/* 63 */insert into Canton(ID_Provincia,nombre) values(5,'Hojancha');

/* 64 */insert into Canton(ID_Provincia,nombre) values(6,'Puntarenas'); 
/* 65 */insert into Canton(ID_Provincia,nombre) values(6,'Esparza'); 
/* 66 */insert into Canton(ID_Provincia,nombre) values(6,'Buenos Aires'); 
/* 67 */insert into Canton(ID_Provincia,nombre) values(6,'Montes de Oro'); 
/* 68 */insert into Canton(ID_Provincia,nombre) values(6,'Osa'); 
/* 69 */insert into Canton(ID_Provincia,nombre) values(6,'Aguirre'); 
/* 70 */insert into Canton(ID_Provincia,nombre) values(6,'Golfito'); 
/* 71 */insert into Canton(ID_Provincia,nombre) values(6,'Coto Brus'); 
/* 72 */insert into Canton(ID_Provincia,nombre) values(6,'Parrita'); 
/* 73 */insert into Canton(ID_Provincia,nombre) values(6,'Corredores'); 
/* 74 */insert into Canton(ID_Provincia,nombre) values(6,'Garabito');

/* 75 */insert into Canton(ID_Provincia,nombre) values(7,'Limon'); 
/* 76 */insert into Canton(ID_Provincia,nombre) values(7,'Pococi'); 
/* 77 */insert into Canton(ID_Provincia,nombre) values(7,'Siquirres'); 
/* 78 */insert into Canton(ID_Provincia,nombre) values(7,'Talamanca'); 
/* 79 */insert into Canton(ID_Provincia,nombre) values(7,'Matina'); 
/* 80 */insert into Canton(ID_Provincia,nombre) values(7,'Guacimo'); 

insert into Distrito(ID_Canton,nombre) values(1,'Carmen'); 
insert into Distrito(ID_Canton,nombre) values(1,'Merced'); 
insert into Distrito(ID_Canton,nombre) values(1,'Hospital'); 
insert into Distrito(ID_Canton,nombre) values(1,'Catedral'); 
insert into Distrito(ID_Canton,nombre) values(1,'Zapote'); 
insert into Distrito(ID_Canton,nombre) values(1,'San Francisco de Dos Rios'); 
insert into Distrito(ID_Canton,nombre) values(1,'Uruca'); 
insert into Distrito(ID_Canton,nombre) values(1,'Mata Redonda'); 
insert into Distrito(ID_Canton,nombre) values(1,'Pavas'); 
insert into Distrito(ID_Canton,nombre) values(1,'Hatillo'); 
insert into Distrito(ID_Canton,nombre) values(1,'San Sebastian'); 
insert into Distrito(ID_Canton,nombre) values(2,'Escazu'); 
insert into Distrito(ID_Canton,nombre) values(2,'San Antonio'); 
insert into Distrito(ID_Canton,nombre) values(2,'San Rafael'); 
insert into Distrito(ID_Canton,nombre) values(3,'Desamparados'); 
insert into Distrito(ID_Canton,nombre) values(3,'San Miguel'); 
insert into Distrito(ID_Canton,nombre) values(3,'San Juan de Dios'); 
insert into Distrito(ID_Canton,nombre) values(3,'San Rafael'); 
insert into Distrito(ID_Canton,nombre) values(3,'San Antonio'); 
insert into Distrito(ID_Canton,nombre) values(3,'Frailes'); 
insert into Distrito(ID_Canton,nombre) values(3,'Patarra'); 
insert into Distrito(ID_Canton,nombre) values(3,'San Cristobal'); 
insert into Distrito(ID_Canton,nombre) values(3,'Rosario'); 
insert into Distrito(ID_Canton,nombre) values(3,'Damas'); 
insert into Distrito(ID_Canton,nombre) values(3,'San Rafael Abajo'); 
insert into Distrito(ID_Canton,nombre) values(3,'Gravillas'); 
insert into Distrito(ID_Canton,nombre) values(4,'Santiago'); 
insert into Distrito(ID_Canton,nombre) values(4,'Mercedes Sur'); 
insert into Distrito(ID_Canton,nombre) values(4,'Barbacoas'); 
insert into Distrito(ID_Canton,nombre) values(4,'Grito Alto'); 
insert into Distrito(ID_Canton,nombre) values(4,'San Rafael'); 
insert into Distrito(ID_Canton,nombre) values(4,'Candelarita'); 
insert into Distrito(ID_Canton,nombre) values(4,'Desamparaditos'); 
insert into Distrito(ID_Canton,nombre) values(4,'San Antonio'); 
insert into Distrito(ID_Canton,nombre) values(4,'Chires'); 
insert into Distrito(ID_Canton,nombre) values(4,'Tarrazu'); 
insert into Distrito(ID_Canton,nombre) values(4,'San Marcos'); 
insert into Distrito(ID_Canton,nombre) values(4,'San Lorenzo'); 
insert into Distrito(ID_Canton,nombre) values(4,'San Carlos'); 
insert into Distrito(ID_Canton,nombre) values(5,'Aserri'); 
insert into Distrito(ID_Canton,nombre) values(5,'Tarbaca'); 
insert into Distrito(ID_Canton,nombre) values(5,'Vuelta de Jorco'); 
insert into Distrito(ID_Canton,nombre) values(5,'San Gabriel'); 
insert into Distrito(ID_Canton,nombre) values(5,'Legua'); 
insert into Distrito(ID_Canton,nombre) values(5,'Monterrey'); 
insert into Distrito(ID_Canton,nombre) values(5,'Salitrillos'); 
insert into Distrito(ID_Canton,nombre) values(6,'Colon'); 
insert into Distrito(ID_Canton,nombre) values(6,'Guayabo'); 
insert into Distrito(ID_Canton,nombre) values(6,'Tabarcia'); 
insert into Distrito(ID_Canton,nombre) values(6,'Piedras Negras'); 
insert into Distrito(ID_Canton,nombre) values(6,'Picagres'); 
insert into Distrito(ID_Canton,nombre) values(7,'Guadalupe'); 
insert into Distrito(ID_Canton,nombre) values(7,'San Francisco'); 
insert into Distrito(ID_Canton,nombre) values(7,'Calle Blancos'); 
insert into Distrito(ID_Canton,nombre) values(7,'Mata de Platano'); 
insert into Distrito(ID_Canton,nombre) values(7,'Ipis'); 
insert into Distrito(ID_Canton,nombre) values(7,'Rancho Redondo'); 
insert into Distrito(ID_Canton,nombre) values(7,'Purral'); 
insert into Distrito(ID_Canton,nombre) values(8,'Santa Ana'); 
insert into Distrito(ID_Canton,nombre) values(8,'Salitral'); 
insert into Distrito(ID_Canton,nombre) values(8,'Pozos'); 
insert into Distrito(ID_Canton,nombre) values(8,'Uruca'); 
insert into Distrito(ID_Canton,nombre) values(8,'Piedades'); 
insert into Distrito(ID_Canton,nombre) values(8,'Brasil'); 
insert into Distrito(ID_Canton,nombre) values(9,'Alajuelita'); 
insert into Distrito(ID_Canton,nombre) values(9,'San Josecito'); 
insert into Distrito(ID_Canton,nombre) values(9,'San Antonio'); 
insert into Distrito(ID_Canton,nombre) values(9,'Concepcion'); 
insert into Distrito(ID_Canton,nombre) values(9,'San Felipe'); 
insert into Distrito(ID_Canton,nombre) values(10,'San Isidro'); 
insert into Distrito(ID_Canton,nombre) values(10,'San Rafael'); 
insert into Distrito(ID_Canton,nombre) values(10,'Jesus (Dulce Nombre)');
insert into Distrito(ID_Canton,nombre) values(10,'Patalillo'); 
insert into Distrito(ID_Canton,nombre) values(10,'Cascajal'); 
insert into Distrito(ID_Canton,nombre) values(11,'San Ignacio'); 
insert into Distrito(ID_Canton,nombre) values(11,'Guaitil'); 
insert into Distrito(ID_Canton,nombre) values(11,'Palmichal'); 
insert into Distrito(ID_Canton,nombre) values(11,'Cangrejal'); 
insert into Distrito(ID_Canton,nombre) values(11,'Sabanillas'); 
insert into Distrito(ID_Canton,nombre) values(12,'San Juan'); 
insert into Distrito(ID_Canton,nombre) values(12,'Cinco Esquinas'); 
insert into Distrito(ID_Canton,nombre) values(12,'Anselmo Llorente'); 
insert into Distrito(ID_Canton,nombre) values(12,'Leon XIII'); 
insert into Distrito(ID_Canton,nombre) values(12,'Colima'); 
insert into Distrito(ID_Canton,nombre) values(13,'San Vicente'); 
insert into Distrito(ID_Canton,nombre) values(13,'San Jeronimo'); 
insert into Distrito(ID_Canton,nombre) values(13,'Trinidad'); 
insert into Distrito(ID_Canton,nombre) values(14,'San Pedro'); 
insert into Distrito(ID_Canton,nombre) values(14,'Sabanilla'); 
insert into Distrito(ID_Canton,nombre) values(14,'Mercedes(tania)'); 
insert into Distrito(ID_Canton,nombre) values(14,'San Rafael'); 
insert into Distrito(ID_Canton,nombre) values(15,'San Pablo'); 
insert into Distrito(ID_Canton,nombre) values(15,'San Pedro'); 
insert into Distrito(ID_Canton,nombre) values(15,'San Juan de Mata'); 
insert into Distrito(ID_Canton,nombre) values(15,'San Luis'); 
insert into Distrito(ID_Canton,nombre) values(16,'Santa Maria'); 
insert into Distrito(ID_Canton,nombre) values(16,'Jardin'); 
insert into Distrito(ID_Canton,nombre) values(16,'Copey'); 
insert into Distrito(ID_Canton,nombre) values(16,'Curridabat'); 
insert into Distrito(ID_Canton,nombre) values(17,'Granadilla'); 
insert into Distrito(ID_Canton,nombre) values(17,'Sanchez'); 
insert into Distrito(ID_Canton,nombre) values(17,'Tirrases'); 
insert into Distrito(ID_Canton,nombre) values(17,'Curridabat'); 
insert into Distrito(ID_Canton,nombre) values(18,'San Isidro del General');
insert into Distrito(ID_Canton,nombre) values(18,'General'); 
insert into Distrito(ID_Canton,nombre) values(18,'Daniel Flores'); 
insert into Distrito(ID_Canton,nombre) values(18,'Rivas'); 
insert into Distrito(ID_Canton,nombre) values(18,'San Pedro'); 
insert into Distrito(ID_Canton,nombre) values(18,'Platanares'); 
insert into Distrito(ID_Canton,nombre) values(18,'Pejibaye'); 
insert into Distrito(ID_Canton,nombre) values(18,'Cajon'); 
insert into Distrito(ID_Canton,nombre) values(18,'Baru'); 
insert into Distrito(ID_Canton,nombre) values(18,'Rio Nuevo'); 
insert into Distrito(ID_Canton,nombre) values(18,'El P�ramo'); 
insert into Distrito(ID_Canton,nombre) values(19,'San Pablo'); 
insert into Distrito(ID_Canton,nombre) values(19,'San Andres'); 
insert into Distrito(ID_Canton,nombre) values(19,'Llano Bonito'); 
insert into Distrito(ID_Canton,nombre) values(19,'San Isidro'); 
insert into Distrito(ID_Canton,nombre) values(19,'Santa Cruz'); 
insert into Distrito(ID_Canton,nombre) values(19,'San Antonio'); 

insert into Distrito(ID_Canton,nombre) values(20,'Alajuela'); 
insert into Distrito(ID_Canton,nombre) values(20,'Carrizal'); 
insert into Distrito(ID_Canton,nombre) values(20,'San Antonio'); 
insert into Distrito(ID_Canton,nombre) values(20,'Guacima'); 
insert into Distrito(ID_Canton,nombre) values(20,'San Isidro'); 
insert into Distrito(ID_Canton,nombre) values(20,'Sabanilla'); 
insert into Distrito(ID_Canton,nombre) values(20,'San Rafael'); 
insert into Distrito(ID_Canton,nombre) values(20,'Rio Segundo'); 
insert into Distrito(ID_Canton,nombre) values(20,'Desamparados'); 
insert into Distrito(ID_Canton,nombre) values(20,'Turrucares'); 
insert into Distrito(ID_Canton,nombre) values(20,'Tambor'); 
insert into Distrito(ID_Canton,nombre) values(20,'Garita'); 
insert into Distrito(ID_Canton,nombre) values(20,'Sarapiqui'); 
insert into Distrito(ID_Canton,nombre) values(21,'San Ramon'); 
insert into Distrito(ID_Canton,nombre) values(21,'Santiago'); 
insert into Distrito(ID_Canton,nombre) values(21,'San Juan'); 
insert into Distrito(ID_Canton,nombre) values(21,'Piedades Norte'); 
insert into Distrito(ID_Canton,nombre) values(21,'Piedades Sur'); 
insert into Distrito(ID_Canton,nombre) values(21,'San Rafael'); 
insert into Distrito(ID_Canton,nombre) values(21,'San Isidro'); 
insert into Distrito(ID_Canton,nombre) values(21,'Angeles'); 
insert into Distrito(ID_Canton,nombre) values(21,'Alfaro'); 
insert into Distrito(ID_Canton,nombre) values(21,'Volio'); 
insert into Distrito(ID_Canton,nombre) values(21,'Concepcion'); 
insert into Distrito(ID_Canton,nombre) values(21,'Zapotal'); 
insert into Distrito(ID_Canton,nombre) values(21,'Pe�as Blancas'); 
insert into Distrito(ID_Canton,nombre) values(22,'Grecia'); 
insert into Distrito(ID_Canton,nombre) values(22,'San Isidro'); 
insert into Distrito(ID_Canton,nombre) values(22,'San Jose'); 
insert into Distrito(ID_Canton,nombre) values(22,'San Roque'); 
insert into Distrito(ID_Canton,nombre) values(22,'Tacares'); 
insert into Distrito(ID_Canton,nombre) values(22,'Rio Cuarto'); 
insert into Distrito(ID_Canton,nombre) values(22,'Puente de Piedra'); 
insert into Distrito(ID_Canton,nombre) values(22,'Bolivar'); 
insert into Distrito(ID_Canton,nombre) values(23,'San Mateo'); 
insert into Distrito(ID_Canton,nombre) values(23,'Desmonte'); 
insert into Distrito(ID_Canton,nombre) values(23,'Jesus Maria'); 
insert into Distrito(ID_Canton,nombre) values(24,'Atenas'); 
insert into Distrito(ID_Canton,nombre) values(24,'Jesus'); 
insert into Distrito(ID_Canton,nombre) values(24,'Mercedes'); 
insert into Distrito(ID_Canton,nombre) values(24,'San Isidro'); 
insert into Distrito(ID_Canton,nombre) values(24,'Concepcion'); 
insert into Distrito(ID_Canton,nombre) values(24,'San Jose'); 
insert into Distrito(ID_Canton,nombre) values(24,'Santa Eulalia'); 
insert into Distrito(ID_Canton,nombre) values(25,'Naranjo'); 
insert into Distrito(ID_Canton,nombre) values(25,'San Miguel'); 
insert into Distrito(ID_Canton,nombre) values(25,'San Jose'); 
insert into Distrito(ID_Canton,nombre) values(25,'Cirri Sur'); 
insert into Distrito(ID_Canton,nombre) values(25,'San Jeronimo'); 
insert into Distrito(ID_Canton,nombre) values(25,'San Juan'); 
insert into Distrito(ID_Canton,nombre) values(25,'Rosario'); 
insert into Distrito(ID_Canton,nombre) values(26,'Palmares'); 
insert into Distrito(ID_Canton,nombre) values(26,'Zaragoza'); 
insert into Distrito(ID_Canton,nombre) values(26,'Buenos Aires'); 
insert into Distrito(ID_Canton,nombre) values(26,'Santiago'); 
insert into Distrito(ID_Canton,nombre) values(26,'Candelaria'); 
insert into Distrito(ID_Canton,nombre) values(26,'Esquipulas'); 
insert into Distrito(ID_Canton,nombre) values(26,'Granja'); 
insert into Distrito(ID_Canton,nombre) values(27,'San Pedro'); 
insert into Distrito(ID_Canton,nombre) values(27,'San Juan'); 
insert into Distrito(ID_Canton,nombre) values(27,'San Rafael'); 
insert into Distrito(ID_Canton,nombre) values(27,'Carrillos'); 
insert into Distrito(ID_Canton,nombre) values(27,'Sabana Redonda'); 
insert into Distrito(ID_Canton,nombre) values(28,'Orotina'); 
insert into Distrito(ID_Canton,nombre) values(28,'Mastate'); 
insert into Distrito(ID_Canton,nombre) values(28,'Hacienda Vieja'); 
insert into Distrito(ID_Canton,nombre) values(28,'Coyolar'); 
insert into Distrito(ID_Canton,nombre) values(28,'Ceiba'); 
insert into Distrito(ID_Canton,nombre) values(29,'Quesada'); 
insert into Distrito(ID_Canton,nombre) values(29,'Florencia'); 
insert into Distrito(ID_Canton,nombre) values(29,'Buenavista'); 
insert into Distrito(ID_Canton,nombre) values(29,'Aguas Zarcas'); 
insert into Distrito(ID_Canton,nombre) values(29,'Venecia'); 
insert into Distrito(ID_Canton,nombre) values(29,'Pital'); 
insert into Distrito(ID_Canton,nombre) values(29,'Fortuna'); 
insert into Distrito(ID_Canton,nombre) values(29,'Tigra'); 
insert into Distrito(ID_Canton,nombre) values(29,'Palmera'); 
insert into Distrito(ID_Canton,nombre) values(29,'Venado'); 
insert into Distrito(ID_Canton,nombre) values(29,'Cutris'); 
insert into Distrito(ID_Canton,nombre) values(29,'Monterrey'); 
insert into Distrito(ID_Canton,nombre) values(29,'Pocosol'); 
insert into Distrito(ID_Canton,nombre) values(30,'Zarcero'); 
insert into Distrito(ID_Canton,nombre) values(30,'Laguna'); 
insert into Distrito(ID_Canton,nombre) values(30,'Tapezco'); 
insert into Distrito(ID_Canton,nombre) values(30,'Guadalupe'); 
insert into Distrito(ID_Canton,nombre) values(30,'Palmira'); 
insert into Distrito(ID_Canton,nombre) values(30,'Zapote'); 
insert into Distrito(ID_Canton,nombre) values(30,'Brisas'); 
insert into Distrito(ID_Canton,nombre) values(31,'Sarchi Norte'); 
insert into Distrito(ID_Canton,nombre) values(31,'Sarchi Sur'); 
insert into Distrito(ID_Canton,nombre) values(31,'Toro Amarillo'); 
insert into Distrito(ID_Canton,nombre) values(31,'San Pedro'); 
insert into Distrito(ID_Canton,nombre) values(31,'Rodriguez'); 
insert into Distrito(ID_Canton,nombre) values(32,'Upala'); 
insert into Distrito(ID_Canton,nombre) values(32,'Aguas Claras'); 
insert into Distrito(ID_Canton,nombre) values(32,'San Jose (Pizote)'); 
insert into Distrito(ID_Canton,nombre) values(32,'Bijagua'); 
insert into Distrito(ID_Canton,nombre) values(32,'Delicias'); 
insert into Distrito(ID_Canton,nombre) values(32,'Dos Rios (Colonia Mayorga)'); 
insert into Distrito(ID_Canton,nombre) values(32,'Yolillal'); 
insert into Distrito(ID_Canton,nombre) values(33,'Los Chiles'); 
insert into Distrito(ID_Canton,nombre) values(33,'Ca�o Negro'); 
insert into Distrito(ID_Canton,nombre) values(33,'El Amparo'); 
insert into Distrito(ID_Canton,nombre) values(33,'San Jorge'); 
insert into Distrito(ID_Canton,nombre) values(34,'San Rafael'); 
insert into Distrito(ID_Canton,nombre) values(34,'Buena Vista'); 
insert into Distrito(ID_Canton,nombre) values(34,'Cote'); 


insert into Distrito(ID_Canton,nombre) values(35,'Oriental'); 
insert into Distrito(ID_Canton,nombre) values(35,'Occidental'); 
insert into Distrito(ID_Canton,nombre) values(35,'Carmen'); 
insert into Distrito(ID_Canton,nombre) values(35,'San Nicolas'); 
insert into Distrito(ID_Canton,nombre) values(35,'Aguacaliente (San Francisco)'); 
insert into Distrito(ID_Canton,nombre) values(35,'Guadalupe (Arenilla)'); 
insert into Distrito(ID_Canton,nombre) values(35,'Corralillo'); 
insert into Distrito(ID_Canton,nombre) values(35,'Tierra Blanca'); 
insert into Distrito(ID_Canton,nombre) values(35,'Dulce Nombre'); 
insert into Distrito(ID_Canton,nombre) values(35,'Llano Grande'); 
insert into Distrito(ID_Canton,nombre) values(35,'Quebradilla'); 
insert into Distrito(ID_Canton,nombre) values(36,'Paraiso'); 
insert into Distrito(ID_Canton,nombre) values(36,'Santiago'); 
insert into Distrito(ID_Canton,nombre) values(36,'Orosi'); 
insert into Distrito(ID_Canton,nombre) values(36,'Cachi'); 
insert into Distrito(ID_Canton,nombre) values(36,'Llanos de Santa Lucia'); 
insert into Distrito(ID_Canton,nombre) values(37,'Tres Rios'); 
insert into Distrito(ID_Canton,nombre) values(37,'San Diego'); 
insert into Distrito(ID_Canton,nombre) values(37,'San Juan'); 
insert into Distrito(ID_Canton,nombre) values(37,'San Rafael'); 
insert into Distrito(ID_Canton,nombre) values(37,'Concepcion'); 
insert into Distrito(ID_Canton,nombre) values(37,'Dulce Nombre'); 
insert into Distrito(ID_Canton,nombre) values(37,'San Ramon'); 
insert into Distrito(ID_Canton,nombre) values(37,'Rio Azul'); 
insert into Distrito(ID_Canton,nombre) values(38,'Juan Vi�as'); 
insert into Distrito(ID_Canton,nombre) values(38,'Tucurrique'); 
insert into Distrito(ID_Canton,nombre) values(38,'Pejibaye'); 
insert into Distrito(ID_Canton,nombre) values(39,'Turrialba'); 
insert into Distrito(ID_Canton,nombre) values(39,'La Suiza'); 
insert into Distrito(ID_Canton,nombre) values(39,'Peralta'); 
insert into Distrito(ID_Canton,nombre) values(39,'Santa cruz'); 
insert into Distrito(ID_Canton,nombre) values(39,'Santa Teresita'); 
insert into Distrito(ID_Canton,nombre) values(39,'Pavones'); 
insert into Distrito(ID_Canton,nombre) values(39,'Tuis'); 
insert into Distrito(ID_Canton,nombre) values(39,'Tayutic'); 
insert into Distrito(ID_Canton,nombre) values(39,'Santa Rosa'); 
insert into Distrito(ID_Canton,nombre) values(39,'Tres Equis'); 
insert into Distrito(ID_Canton,nombre) values(39,'La Isabel'); 
insert into Distrito(ID_Canton,nombre) values(39,'Chirripo'); 
insert into Distrito(ID_Canton,nombre) values(40,'Pacayas'); 
insert into Distrito(ID_Canton,nombre) values(40,'Cervantes'); 
insert into Distrito(ID_Canton,nombre) values(40,'Capellades'); 
insert into Distrito(ID_Canton,nombre) values(41,'San Rafael'); 
insert into Distrito(ID_Canton,nombre) values(41,'Cot'); 
insert into Distrito(ID_Canton,nombre) values(41,'Potrero Cerrado'); 
insert into Distrito(ID_Canton,nombre) values(41,'Cipreses'); 
insert into Distrito(ID_Canton,nombre) values(41,'Santa Rosa'); 
insert into Distrito(ID_Canton,nombre) values(42,'Tejar'); 
insert into Distrito(ID_Canton,nombre) values(42,'San Isidro'); 
insert into Distrito(ID_Canton,nombre) values(42,'Tobosi'); 
insert into Distrito(ID_Canton,nombre) values(42,'Patio de Agua'); 

insert into Distrito(ID_Canton,nombre) values(43,'Heredia'); 
insert into Distrito(ID_Canton,nombre) values(43,'Mercedes'); 
insert into Distrito(ID_Canton,nombre) values(43,'San Francisco'); 
insert into Distrito(ID_Canton,nombre) values(43,'Ulloa'); 
insert into Distrito(ID_Canton,nombre) values(43,'Varablanca'); 
insert into Distrito(ID_Canton,nombre) values(44,'Barva'); 
insert into Distrito(ID_Canton,nombre) values(44,'San Pedro'); 
insert into Distrito(ID_Canton,nombre) values(44,'San Pablo'); 
insert into Distrito(ID_Canton,nombre) values(44,'San Roque'); 
insert into Distrito(ID_Canton,nombre) values(44,'Santa Lucia'); 
insert into Distrito(ID_Canton,nombre) values(44,'San Jose de la Monta�a'); 
insert into Distrito(ID_Canton,nombre) values(45,'Santo Domingo'); 
insert into Distrito(ID_Canton,nombre) values(45,'San Vicente'); 
insert into Distrito(ID_Canton,nombre) values(45,'San Miguel'); 
insert into Distrito(ID_Canton,nombre) values(45,'Paracito'); 
insert into Distrito(ID_Canton,nombre) values(45,'Santo Tomas'); 
insert into Distrito(ID_Canton,nombre) values(45,'Santa Rosa'); 
insert into Distrito(ID_Canton,nombre) values(45,'Tures'); 
insert into Distrito(ID_Canton,nombre) values(45,'Para'); 
insert into Distrito(ID_Canton,nombre) values(46,'Santa Barbara'); 
insert into Distrito(ID_Canton,nombre) values(46,'San Pedro'); 
insert into Distrito(ID_Canton,nombre) values(46,'San Juan'); 
insert into Distrito(ID_Canton,nombre) values(46,'Jesus'); 
insert into Distrito(ID_Canton,nombre) values(46,'Santo Domingo'); 
insert into Distrito(ID_Canton,nombre) values(46,'Puraba'); 
insert into Distrito(ID_Canton,nombre) values(47,'San Rafael'); 
insert into Distrito(ID_Canton,nombre) values(47,'San Josecito'); 
insert into Distrito(ID_Canton,nombre) values(47,'Santiago'); 
insert into Distrito(ID_Canton,nombre) values(47,'Angeles'); 
insert into Distrito(ID_Canton,nombre) values(47,'Concepcion'); 
insert into Distrito(ID_Canton,nombre) values(48,'San Isidro'); 
insert into Distrito(ID_Canton,nombre) values(48,'San Jose'); 
insert into Distrito(ID_Canton,nombre) values(48,'Concepcion'); 
insert into Distrito(ID_Canton,nombre) values(48,'San Francisco'); 
insert into Distrito(ID_Canton,nombre) values(49,'San Antonio'); 
insert into Distrito(ID_Canton,nombre) values(49,'Ribera'); 
insert into Distrito(ID_Canton,nombre) values(49,'Asuncion'); 
insert into Distrito(ID_Canton,nombre) values(50,'San Joaquin de Flores'); 
insert into Distrito(ID_Canton,nombre) values(50,'Barrantes'); 
insert into Distrito(ID_Canton,nombre) values(50,'Llorente'); 
insert into Distrito(ID_Canton,nombre) values(51,'San Pablo'); 
insert into Distrito(ID_Canton,nombre) values(51,'Rincon de Sabanilla'); 
insert into Distrito(ID_Canton,nombre) values(52,'Puerto Viejo'); 
insert into Distrito(ID_Canton,nombre) values(52,'La Virgen'); 
insert into Distrito(ID_Canton,nombre) values(52,'Horquetas'); 
insert into Distrito(ID_Canton,nombre) values(52,'Llanuras del Gaspar'); 
insert into Distrito(ID_Canton,nombre) values(52,'Cure�a');

insert into Distrito(ID_Canton,nombre) values(53,'Liberia'); 
insert into Distrito(ID_Canton,nombre) values(53,'Ca�as Dulces'); 
insert into Distrito(ID_Canton,nombre) values(53,'Mayorga'); 
insert into Distrito(ID_Canton,nombre) values(53,'Nacascolo'); 
insert into Distrito(ID_Canton,nombre) values(53,'Curubande'); 
insert into Distrito(ID_Canton,nombre) values(54,'Nicoya'); 
insert into Distrito(ID_Canton,nombre) values(54,'Mansion'); 
insert into Distrito(ID_Canton,nombre) values(54,'San Antonio'); 
insert into Distrito(ID_Canton,nombre) values(54,'Quebrada Honda'); 
insert into Distrito(ID_Canton,nombre) values(54,'Samara'); 
insert into Distrito(ID_Canton,nombre) values(54,'Nosara'); 
insert into Distrito(ID_Canton,nombre) values(54,'Belen de Nosarita'); 
insert into Distrito(ID_Canton,nombre) values(55,'Santa Cruz'); 
insert into Distrito(ID_Canton,nombre) values(55,'Bolson'); 
insert into Distrito(ID_Canton,nombre) values(55,'Veintisiete de Abril'); 
insert into Distrito(ID_Canton,nombre) values(55,'Tempate'); 
insert into Distrito(ID_Canton,nombre) values(55,'Cartagena'); 
insert into Distrito(ID_Canton,nombre) values(55,'Coajiniquil'); 
insert into Distrito(ID_Canton,nombre) values(55,'Diria'); 
insert into Distrito(ID_Canton,nombre) values(55,'Cabo Velas'); 
insert into Distrito(ID_Canton,nombre) values(55,'Tamarindo'); 
insert into Distrito(ID_Canton,nombre) values(56,'Bagaces'); 
insert into Distrito(ID_Canton,nombre) values(56,'Fortuna'); 
insert into Distrito(ID_Canton,nombre) values(56,'Mogote'); 
insert into Distrito(ID_Canton,nombre) values(56,'Rio Naranjo'); 
insert into Distrito(ID_Canton,nombre) values(57,'Filadelfia'); 
insert into Distrito(ID_Canton,nombre) values(57,'Palmira'); 
insert into Distrito(ID_Canton,nombre) values(57,'Sardinal'); 
insert into Distrito(ID_Canton,nombre) values(57,'Belen'); 
insert into Distrito(ID_Canton,nombre) values(58,'Ca�as'); 
insert into Distrito(ID_Canton,nombre) values(58,'Palmira'); 
insert into Distrito(ID_Canton,nombre) values(58,'San Miguel'); 
insert into Distrito(ID_Canton,nombre) values(58,'Bebedero'); 
insert into Distrito(ID_Canton,nombre) values(58,'Porozal'); 
insert into Distrito(ID_Canton,nombre) values(59,'Juntas'); 
insert into Distrito(ID_Canton,nombre) values(59,'Sierra'); 
insert into Distrito(ID_Canton,nombre) values(59,'San Juan'); 
insert into Distrito(ID_Canton,nombre) values(59,'Colorado'); 
insert into Distrito(ID_Canton,nombre) values(60,'Tilaran'); 
insert into Distrito(ID_Canton,nombre) values(60,'Quebrada Grande'); 
insert into Distrito(ID_Canton,nombre) values(60,'Tronadora'); 
insert into Distrito(ID_Canton,nombre) values(60,'Santa Rosa'); 
insert into Distrito(ID_Canton,nombre) values(60,'Libano'); 
insert into Distrito(ID_Canton,nombre) values(60,'Tierras Morenas'); 
insert into Distrito(ID_Canton,nombre) values(60,'Arenal'); 
insert into Distrito(ID_Canton,nombre) values(61,'Carmona'); 
insert into Distrito(ID_Canton,nombre) values(61,'Santa Rita'); 
insert into Distrito(ID_Canton,nombre) values(61,'Zapotal'); 
insert into Distrito(ID_Canton,nombre) values(61,'San Pablo'); 
insert into Distrito(ID_Canton,nombre) values(61,'Porvenir'); 
insert into Distrito(ID_Canton,nombre) values(61,'Bejuco'); 
insert into Distrito(ID_Canton,nombre) values(62,'La Cruz'); 
insert into Distrito(ID_Canton,nombre) values(62,'Santa Cecilia'); 
insert into Distrito(ID_Canton,nombre) values(62,'Garita'); 
insert into Distrito(ID_Canton,nombre) values(62,'Santa Elena'); 
insert into Distrito(ID_Canton,nombre) values(63,'Hojancha'); 
insert into Distrito(ID_Canton,nombre) values(63,'Monte Romo'); 
insert into Distrito(ID_Canton,nombre) values(63,'Puerto Carrillo'); 
insert into Distrito(ID_Canton,nombre) values(63,'Huacas');

insert into Distrito(ID_Canton,nombre) values(64,'Puntarenas'); 
insert into Distrito(ID_Canton,nombre) values(64,'Pitahaya'); 
insert into Distrito(ID_Canton,nombre) values(64,'Chomes'); 
insert into Distrito(ID_Canton,nombre) values(64,'Lepanto'); 
insert into Distrito(ID_Canton,nombre) values(64,'Paquera'); 
insert into Distrito(ID_Canton,nombre) values(64,'Manzanillo'); 
insert into Distrito(ID_Canton,nombre) values(64,'Guacimal'); 
insert into Distrito(ID_Canton,nombre) values(64,'Barranca'); 
insert into Distrito(ID_Canton,nombre) values(64,'Monte Verde'); 
insert into Distrito(ID_Canton,nombre) values(64,'Isla del Coco'); 
insert into Distrito(ID_Canton,nombre) values(64,'Cobano'); 
insert into Distrito(ID_Canton,nombre) values(64,'Chacarita'); 
insert into Distrito(ID_Canton,nombre) values(64,'Chira'); 
insert into Distrito(ID_Canton,nombre) values(64,'Acapulco'); 
insert into Distrito(ID_Canton,nombre) values(64,'El Roble'); 
insert into Distrito(ID_Canton,nombre) values(64,'Arancibia'); 
insert into Distrito(ID_Canton,nombre) values(65,'Espiritu Santo'); 
insert into Distrito(ID_Canton,nombre) values(65,'San Juan Grande'); 
insert into Distrito(ID_Canton,nombre) values(65,'Macacona'); 
insert into Distrito(ID_Canton,nombre) values(65,'San Rafael'); 
insert into Distrito(ID_Canton,nombre) values(65,'San Jeronimo'); 
insert into Distrito(ID_Canton,nombre) values(66,'Buenos Aires'); 
insert into Distrito(ID_Canton,nombre) values(66,'Volcan'); 
insert into Distrito(ID_Canton,nombre) values(66,'Potrero Grande'); 
insert into Distrito(ID_Canton,nombre) values(66,'Boruca'); 
insert into Distrito(ID_Canton,nombre) values(66,'Pilas'); 
insert into Distrito(ID_Canton,nombre) values(66,'Colinas'); 
insert into Distrito(ID_Canton,nombre) values(66,'Changuenas'); 
insert into Distrito(ID_Canton,nombre) values(66,'Biolley'); 
insert into Distrito(ID_Canton,nombre) values(67,'Miramar'); 
insert into Distrito(ID_Canton,nombre) values(67,'Union'); 
insert into Distrito(ID_Canton,nombre) values(67,'San Isidro'); 
insert into Distrito(ID_Canton,nombre) values(68,'Cortes'); 
insert into Distrito(ID_Canton,nombre) values(68,'Palmar'); 
insert into Distrito(ID_Canton,nombre) values(68,'Sierpe'); 
insert into Distrito(ID_Canton,nombre) values(68,'Bahia Ballena'); 
insert into Distrito(ID_Canton,nombre) values(68,'Piedras Blancas'); 
insert into Distrito(ID_Canton,nombre) values(69,'Quepos'); 
insert into Distrito(ID_Canton,nombre) values(69,'Savegre'); 
insert into Distrito(ID_Canton,nombre) values(69,'Naranjito'); 
insert into Distrito(ID_Canton,nombre) values(70,'Golfito'); 
insert into Distrito(ID_Canton,nombre) values(70,'Jimenez'); 
insert into Distrito(ID_Canton,nombre) values(70,'Guaycar'); 
insert into Distrito(ID_Canton,nombre) values(70,'Corredor'); 
insert into Distrito(ID_Canton,nombre) values(71,'San Vito'); 
insert into Distrito(ID_Canton,nombre) values(71,'Sabalito'); 
insert into Distrito(ID_Canton,nombre) values(71,'Aguabuena'); 
insert into Distrito(ID_Canton,nombre) values(71,'Limoncito'); 
insert into Distrito(ID_Canton,nombre) values(71,'Pittier'); 
insert into Distrito(ID_Canton,nombre) values(72,'Parrita'); 
insert into Distrito(ID_Canton,nombre) values(73,'Corredores'); 
insert into Distrito(ID_Canton,nombre) values(73,'La Cuesta'); 
insert into Distrito(ID_Canton,nombre) values(73,'Canoas'); 
insert into Distrito(ID_Canton,nombre) values(73,'Laurel'); 
insert into Distrito(ID_Canton,nombre) values(74,'Jaco'); 
insert into Distrito(ID_Canton,nombre) values(74,'Tarcoles');

insert into Distrito(ID_Canton,nombre) values(75,'Limon'); 
insert into Distrito(ID_Canton,nombre) values(75,'Valle la Estrella'); 
insert into Distrito(ID_Canton,nombre) values(75,'Rio Blanco'); 
insert into Distrito(ID_Canton,nombre) values(75,'Matama'); 
insert into Distrito(ID_Canton,nombre) values(76,'Guapiles'); 
insert into Distrito(ID_Canton,nombre) values(76,'Jimenez'); 
insert into Distrito(ID_Canton,nombre) values(76,'Rita'); 
insert into Distrito(ID_Canton,nombre) values(76,'Roxana'); 
insert into Distrito(ID_Canton,nombre) values(76,'Cariari'); 
insert into Distrito(ID_Canton,nombre) values(76,'Colorado'); 
insert into Distrito(ID_Canton,nombre) values(77,'Siquirres'); 
insert into Distrito(ID_Canton,nombre) values(77,'Pacuarito'); 
insert into Distrito(ID_Canton,nombre) values(77,'Florida'); 
insert into Distrito(ID_Canton,nombre) values(77,'Germania'); 
insert into Distrito(ID_Canton,nombre) values(77,'Cairo'); 
insert into Distrito(ID_Canton,nombre) values(77,'Alegria'); 
insert into Distrito(ID_Canton,nombre) values(78,'Bratsi'); 
insert into Distrito(ID_Canton,nombre) values(78,'Sixaola'); 
insert into Distrito(ID_Canton,nombre) values(78,'Cahuita'); 
insert into Distrito(ID_Canton,nombre) values(79,'Matina'); 
insert into Distrito(ID_Canton,nombre) values(79,'Batan'); 
insert into Distrito(ID_Canton,nombre) values(79,'Carrandi'); 
insert into Distrito(ID_Canton,nombre) values(80,'Guacimo'); 
insert into Distrito(ID_Canton,nombre) values(80,'Mercedes'); 
insert into Distrito(ID_Canton,nombre) values(80,'Pocora'); 
insert into Distrito(ID_Canton,nombre) values(80,'Rio Jimenez'); 
insert into Distrito(ID_Canton,nombre) values(80,'Duacari');