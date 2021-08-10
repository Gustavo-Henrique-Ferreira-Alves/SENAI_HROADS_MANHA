USE SENAI_HROADS_MANHA;
GO

INSERT INTO CLASSE(nomeClasse)
VALUES				 ('Bárbaro')
					,('Cruzado')
					,('Caçadora de Demônios')
					,('Monge')
					,('Necromante')
					,('Feiticeiro')
					,('Arcanista')

INSERT INTO PERSONAGEM(nomePersonagem, idClasse, QtndVida, QtndMana, DataAtualizacao, DataCriacao)
VALUES					('DeuBug', 1, 100, 80, '01-03-2021', '18-01-2019')
					   ,('BitBug', 4, 70, 100, '01-03-2021', '17-03-2016')
					   ,('Fer8', 7, 75, 60, '01-03-2021', '18-03-2018')

INSERT INTO TIPO_HABILIDADE(nomeTipoHab)
VALUES						('Ataque')
						   ,('Defesa')
						   ,('Cura')
						   ,('Magia')

INSERT INTO HABILIDADE(nomeHabilidade, idTipoHab)
VALUES					('Lança Mortal', 1)
					   ,('Escudo Supremo', 2)
					   ,('Recuperar Vida', 3)

INSERT INTO CLASSE_HABILIDADE(idClasse, idHabilidade)
VALUES							 (1, 1)
								,(1, 2)
								,(2, 2)
								,(3, 1)
								,(4, 3)
								,(4, 2)
								,(6, 3)

UPDATE PERSONAGEM
SET nomePersonagem = 'Fer7'
WHERE idPersonagem = 3

UPDATE CLASSE
SET nomeClasse = 'Necromancer'
WHERE idClasSE = 5
