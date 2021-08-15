CREATE database ClubDeLectura
use ClubDeLectura

--La Clave unica se rellena autoomaticamente con los datos de la persona
create table Usuario	(claveU varchar(18) primary key, nombre varchar(150), correo varchar (150), contraseña varchar(50), telefono varchar(10), direccion varchar(250))

create table Temas (idT int primary key, nombre varchar(40))

create table Administrador (cAdmin varchar(15) primary key, nombre varchar(150), contraseña varchar(50), telefono varchar (10), direccion varchar(250))

create table Genero		(cGen int primary key, nombre varchar(150))

--La clave del libro será diferente al ISBN, la clave es la de registro en la app
--El ISBN normalmente consta de 13 digitos
create table Libro		(cLibro int primary key, titulo varchar(150), reseña varchar(250), ISBN varchar(13), cGen int references Genero, autor varchar(150))

create table Sala (cSala int primary key, nombre varchar(100), anfitrion varchar(18) references Usuario, idTema int references Temas, idLibro int references Libro, FechaC datetime, FechaCierre datetime, Cupo int)

create table Reunion (idReunion int primary key, idSala int references Sala, fechaR datetime, duracion int, linkR varchar(300))

create table seUne (idSala int references Sala, idUsuario varchar(18) references Usuario, fechaUnion datetime, primary key(idSala, idUsuario))



--INSERTS

insert into Genero Values(10, 'Filosofía')
insert into Genero Values(20, 'Técnica')
insert into Genero Values(30, 'Poesía')
insert into Genero Values(40, 'Historia')
insert into Genero Values(50, 'Novela')
insert into Genero Values(60, 'Psicología')
insert into Genero Values(70, 'Ciencia')
--delete from Usuario
select * from Genero

insert into Libro values (1000 ,'El tránsito terreno','reseña','84-121-2310-1', 10, 'Emilio Carrillo')
insert into Libro values (2000 ,'Animales salvajes','reseña','84-7489-146-9', 70, 'Jane Burton')
insert into Libro values (3000 ,'Poemas intrínsecos','reseña','84-305-0473-7', 30, 'Llorens Antonia')
insert into Libro values (4000 ,'Avances en Arquitectura','reseña','84-473-0120-6', 40, 'Richte Helmut')
insert into Libro values (5000 ,'Las balas del bien','reseña','84-206-1704-0', 50, 'Leverling, Janet')
insert into Libro values (6000 ,'La mente y el sentir','reseña','84-226-2128-2', 10, 'Plasencia, Juan Luis')
insert into Libro values (7000 ,'Ensayos póstumos','reseña','84-7908-349-2', 60, 'Bertomeu, Andrés')
insert into Libro values (8000 ,'Ensayos póstumos','reseña','84-7908-349-2', 60, 'Bertomeu, Andrés')

--delete from Libro
select * from Libro

insert into Temas values (1, 'Debate')
insert into Temas values (2, 'Analisis')
insert into Temas values (3, 'Lectura grupal')
insert into Temas values (4, 'Guia')
insert into Temas values (5, 'Reinterpretacion')
insert into Temas values (6, 'Opiniones')
--delete from Temas
select * from Temas

insert into Usuario values('Paza557','Paulina Garza', 'paulinaG@gmail.com','pau','5555555555','Calle1')
insert into Usuario values('Eria559','Ernesto Garcia', 'ernestoG@gmail.com', 'ernesto','5555555555','Calle2')
insert into Usuario values('Raro5512','Rafael Navarro', 'rafaelN@gmail.com', 'rafa','5555555555','Calle3')
insert into Usuario values('Leez579','Leilani Dominguez', 'leilaniD@gmail.com', 'leilani','5555555555','Calle4')
insert into Usuario values('Raro5513','Rafael Navarro', 'rafaelN@gmail.com', 'rafa','5555555555','Calle3')
--delete from Usuario
select * from Usuario

insert into Administrador values ( 'AFodhyndtgciur', 'Alejandra Flores', 'ale','5555555555','calle5')
--delete from Administrador
select * from Administrador

insert into Sala values	(1, 'Reflexiones y analisis', 'Raro5512', 2, 1000, '2020-10-24', '2022-10-24',30);
insert into Sala values	(2, 'Reinterpretacion dialectica', 'Eria559', 4, 3000, '2020-01-02', '2022-01-02',50);
insert into Sala values	(3, 'Etica y moral', 'Paza557', 6, 5000, '2020-11-14', '2022-11-14',20);
insert into Sala values	(4, 'Los comienzos', 'Leez579', 3, 2000, '2020-11-14', '2022-11-14',50);
insert into Sala values	(6, 'Los comienzos', 'Raro5512', 4, 3000, '2020-11-14 20:15', '2022-11-14 00:00',50);
--delete from Sala
select * from Sala

insert into seUne values (1, 'Paza557', '2020-10-24');
insert into seUne values (2, 'Raro5512', '2020-10-24');
insert into seUne values (3, 'Eria559', '2020-10-24');
insert into seUne values (4, 'Leez579', '2020-10-24');
insert into seUne values (4, 'Paza557', '2020-10-24');
insert into seUne values (3, 'Raro5512', '2020-10-24');
insert into seUne values (2, 'Eria559', '2020-10-24');
insert into seUne values (1, 'Leez579', '2020-10-24');
--delete from seUne
select * from seUne

insert into Reunion values (1, 1, '2020-10-24', 120, 'https://meet.google.com/01')
insert into Reunion values (2, 2, '2020-10-25', 180, 'https://meet.google.com/02')
insert into Reunion values (3, 4, '2020-10-26', 80, 'https://meet.google.com/03')
insert into Reunion values (4, 1, '2020-10-27', 20, 'https://meet.google.com/04')
insert into Reunion values (5, 3, '2020-10-26', 60, 'https://meet.google.com/05')
insert into Reunion values (6, 2, '2020-10-24', 120, 'https://meet.google.com/06')
insert into Reunion values (7, 4, '2020-10-25', 180, 'https://meet.google.com/07')
insert into Reunion values (8, 1, '2020-10-26', 80, 'https://meet.google.com/08')
insert into Reunion values (9, 3, '2020-10-27', 20, 'https://meet.google.com/09')
--delete from Reunion
select * from Reunion