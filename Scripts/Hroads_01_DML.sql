USE SENAI_HROADS_MANHA;
GO

INSERT INTO CLASSES(nomeClasse)
VALUES				 ('Bárbaro')
					,('Cruzado')
					,('Caçadora de Demônios')
					,('Monge')
					,('Necromante')
					,('Feiticeiro')
					,('Arcanista')

INSERT INTO PERSONAGENS(nomePersonagem, idClasse, QtndVida, QtndMana, DataAtualizacao, DataCriacao)
VALUES					('DeuBug', 1, 100, 80, '01-03-2021', '18-01-2019')
					   ,('BitBug', 4, 70, 100, '01-03-2021', '17-03-2016')
					   ,('Fer8', 7, 75, 60, '01-03-2021', '18-03-2018')

INSERT INTO TIPOS_HABILIDADE(nomeTipoHab)
VALUES						('Ataque')
						   ,('Defesa')
						   ,('Cura')
						   ,('Magia')

INSERT INTO HABILIDADES(nomeHabilidade, idTipoHab)
VALUES					('Lança Mortal', 1)
					   ,('Escudo Supremo', 2)
					   ,('Recuperar Vida', 3)

INSERT INTO CLASSES_HABILIDADE(idClasse, idHabilidade)
VALUES							 (1, 1)
								,(1, 2)
								,(2, 2)
								,(3, 1)
								,(4, 3)
								,(4, 2)
								,(6, 3)

UPDATE PERSONAGENS
SET nomePersonagem = 'Fer7'
WHERE idPersonagem = 3

UPDATE CLASSES
SET nomeClasse = 'Necromancer'
WHERE idClasSE = 5

INSERT INTO TIPOS_USUARIO(titulo)
VALUES ('Administrador')
	  ,('Jogador');
GO

INSERT INTO USUARIOS(idTipoUser, email, senha)
VALUES (1, 'adm@adm.com','adm')
	  ,(2, 'jogador@jogador.com','jogador');
GO