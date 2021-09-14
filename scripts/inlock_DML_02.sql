USE inlock_games;
GO

INSERT INTO estudio( nomeEstudio)
VALUES 
		('Blizzard'),
		('Rockstar Studios'),
		('Square Enix')

GO

INSERT INTO jogos(idEstudio, nomeJogo, descricao, dataLancamento, valor)
VALUES
		('1', 'Diablo 3', 'É um jogo que contém bastante
ação e é viciante, seja você um novato ou um fã.', '2012-05-15', '99.00'),
		('2', 'Red Dead Redemption II', 'Jogo
eletrônico de ação-aventura western.', '2018-10-16', '120.00')

GO

INSERT INTO tipoUsuario(tituloUsuario)
VALUES
		('Administrador'),
		('Cliente')
GO

INSERT INTO usuario(idTipoUsuario, nome, email, senha)
VALUES
		('1', 'Fernanda', 'admin@admin.com', 'admin'),
		('2', 'Alberto', 'cliente@cliente.com', 'cliente')

GO