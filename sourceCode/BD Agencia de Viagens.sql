use tripagency;
SELECT * FROM RostoFuncionario;

SELECT 
    f.Nome, l.username, l.data_login, l.data_logout
	FROM log_acessos l INNER JOIN funcionarios f ON l.funcionario_id = f.id;


CREATE TABLE administradores (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    senha VARCHAR(100) NOT NULL
);

INSERT INTO administradores (username, senha) VALUES
('1', '1'),
('hernani', 'admin'),
('beny', 'admin'),
('naza', 'admin'),
('julio', 'admin'),
('jolinda', 'admin'),
('david', 'admin'),
('aldo', 'admin');


Create Table funcionarios(
id INT AUTO_INCREMENT PRIMARY KEY,
Nome Varchar(150) NOT NULL,
Username Varchar(150) NOT NULL,
Senha Varchar(150) NOT NULL,
Numero_do_BI Varchar(50) UNIQUE NOT NULL,
Nacionalidade Varchar(30) NOT NULL,
Genero ENUM("M","F") NOT NULL,
Data_de_Nascimento date NOT NULL,
Endereco Varchar(100) NOT NULL,
Telefone Varchar(20) NOT NULL,
Email Varchar(30) NOT NULL
);

CREATE TABLE RostoFuncionario (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    FuncionarioId INT NOT NULL,
    RostoLbp LONGBLOB,
    DataCadastro DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (FuncionarioId) REFERENCES funcionarios(id)
	ON DELETE CASCADE);

CREATE TABLE log_acessos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    funcionario_id INT,
    username VARCHAR(100),
    data_login DATETIME,
    data_logout DATETIME,
    FOREIGN KEY (funcionario_id) REFERENCES funcionarios(id)
	ON DELETE CASCADE);


Create Table Clientes(
Id_Cliente INT AUTO_INCREMENT PRIMARY KEY,
Nome Varchar(150) NOT NULL,
Numero_de_Passaporte Varchar(50) UNIQUE NOT NULL,
Numero_do_BI Varchar(50) UNIQUE NOT NULL,
Nacionalidade Varchar(30) NOT NULL,
Genero ENUM("M","F") NOT NULL,
Data_de_Nascimento date NOT NULL,
Endereco Varchar(100) NOT NULL,
Telefone Varchar(20) NOT NULL,
Email Varchar(30) NOT NULL,
Data_Cadastro datetime default current_timestamp
);

CREATE TABLE paises (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL
);
CREATE TABLE cidades (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    precoCidades FLOAT NOT NULL,
    pais_id INT NOT NULL,
    FOREIGN KEY (pais_id) REFERENCES paises(id)
);
CREATE TABLE hoteis(
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    precoHoteis FLOAT NOT NULL,
    cidades_id INT NOT NULL,
    FOREIGN KEY (cidades_id) REFERENCES cidades(id)
);

CREATE TABLE aeroportos(
	id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    precoAeroportos FLOAT NOT NULL,
    cidades_id INT NOT NULL,
    FOREIGN KEY (cidades_id) REFERENCES cidades(id)
);

CREATE TABLE companhias(
	id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    precoCompanhias FLOAT NOT NULL,
    id_paises INT NOT NULL,
    FOREIGN KEY (id_paises) REFERENCES paises(id)
);

CREATE TABLE reservas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    cliente_id INT NOT NULL,
    pais_id INT NOT NULL,
    cidade_id INT NOT NULL,
    hotel_id INT NOT NULL,
    aeroporto_id INT NOT NULL,
    companhia_id INT NOT NULL,
    data_viagem DATE NOT NULL,
    data_retorno DATE NOT NULL,
    total_preco FLOAT NOT NULL,
    dias INT NOT NULL,
    pessoas INT NOT NULL,
    classe VARCHAR(50) NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES Clientes(Id_Cliente),
    FOREIGN KEY (pais_id) REFERENCES paises(id),
    FOREIGN KEY (cidade_id) REFERENCES cidades(id),
    FOREIGN KEY (hotel_id) REFERENCES hoteis(id),
    FOREIGN KEY (aeroporto_id) REFERENCES aeroportos(id),
    FOREIGN KEY (companhia_id) REFERENCES companhias(id)
);


INSERT INTO paises (nome) VALUES 
    ('Portugal'),
    ('Espanha'),
    ('França'),
    ('Itália'),
    ('Alemanha'),
    ('Inglaterra'),
    ('China'),
    ('Japão'),
    ('USA'),
    ('Canadá'),
    ('Brasil'),
    ('México'),
    ('Argentina'),
    ('Egipto'),
    ('África do Sul'),
    ('Namibia'),
    ('Angola');


INSERT INTO cidades (nome, precoCidades, pais_id) VALUES 
    ('Lisboa', 1200, 1),
    ('Porto', 1100, 1),
    ('Madrid', 1250, 2),
    ('Barcelona', 1250, 2),
    ('Sevilha', 1210, 2),
    ('Paris', 1600, 3),
    ('Lyon', 1220, 3),
    ('Marselha', 1300, 3),
    ('Roma', 1315, 4),
    ('Milão', 1346,4),
    ('Veneza', 1368, 4),
    ('Berlim', 1654, 5),
    ('Frankfurt', 1256, 5),
    ('Munique', 1006, 5),
    ('Londres', 1477, 6),
    ('Manchester', 1321, 6),
    ('Liverpool', 1179, 6),
    ('Shangai', 1050, 7),
    ('Pequim', 1030, 7),
    ('Shenzhen', 1000, 7),
    ('Tóquio', 1340, 8),
    ('Yokohama', 1010, 8),
    ('Osaka', 1000, 8),
    ('Washington', 1400, 9),
    ('New York', 1780, 9),
    ('Los Angeles', 1730, 9),
    ('Miami', 1690, 9),
    ('Toronto', 1100, 10),
    ('Vancouver', 1140, 10),
    ('São Paulo', 1200, 11),
    ('Rio de Janeiro', 1440, 11),
    ('Brasilia', 1100, 11),
    ('Cidade do México', 1100, 12),
    ('Cancún', 1540, 12),
    ('Bueno Aires', 1130, 13),
    ('Cairo', 1020, 14),
    ('Cape Town', 1040, 15),
    ('Johanesburgo', 1010, 15),
    ('Windhoek', 1000, 16),
    ('Luanda', 300, 17),
    ('Benguela', 300, 17),
    ('Lubango', 300, 17),
    ('Namibe', 300, 17);
    
    
INSERT INTO hoteis (nome, precoHoteis, cidades_id) VALUES 
    ('Hotel Avenida Palace', 300, 1),
    ('The Yeatman', 300, 2),
    ('Hotel Wellington', 300, 3),
    ('W Barcelona', 300, 4),
    ('Hotel Alfonso XIII', 300, 5),
    ('Hotel Paris Louis Blanc', 300, 6),
    ('Boscolo Lyon Hotel', 300, 7),
    ('Hotel Le Negresco', 300, 8),
    ('Hotel Hassler Roma', 300, 9),
    ('Armani Hotel Milano', 300, 10),
    ('Belmond Hotel Cipriani', 300, 11),
    ('Hotel Adlon Kempinski', 300, 12),
    ('Jumeirah Frankfurt', 300, 13),
    ('Bayerischer Hof', 300, 14),
    ('The Langham', 300, 15),
    ('The Plaza Hotel', 300, 15),
    ('Hotel Gotham', 300, 16),
    ('Titanic Hotel Liverpool', 300, 17),
    ('The Peninsula Shanghai', 300, 18),
    ('Rosewood Beijing', 300, 19),
    ('The Ritz-Carlton', 300, 20),
	('Park Hyatt Tokyo', 300, 21),
    ('InterContinental Yokohama Grand', 300, 22),
    ('The St. Regis Osaka', 300, 23),
    ('The Hay-Adams', 300, 24),
    ('The Plaza Hotel', 300, 25),
    ('The Beverly Hills Hotel', 300, 26),
    ('The Setai, Miami Beach', 300, 27),
    ('Fairmont Royal York', 300, 28),
    ('Rosewood Hotel Georgia', 300, 29),
    ('Hotel Unique', 300, 30),
	('Belmond Copacabana Palace', 300, 31),
    ('Melia Brasil 21', 300, 32),
    ('Four Seasons Hotel Mexico City', 300, 33),
    ('Waldorf Astoria Cancún', 300, 34),
    ('Palacio Duhau – Park Hyatt Buenos Aires', 300, 35),
    ('Marriott Mena House Cairo', 300, 36),
    ('One&Only Cape Town', 300, 37),
    ('The Saxon Hotel, Villas & Spa', 300, 38),
    ('Hilton Windhoek', 300, 39),
    ('Hotel Presidente', 300, 40),
    ('EPIC SANA Luanda Hotel', 300, 40),
    ('Hotel Praia Morena', 300, 41),
    ('Hotel Ombaka Ritz', 300, 41),
    ('Pululukwa Resort', 300, 42),
    ('Hotel Serra da Chela', 300, 42),
    ('Infotur Namibe', 300, 43),
    ('Hotel Chik Chik Namibe', 300, 43);


INSERT INTO aeroportos (nome, precoAeroportos, cidades_id) VALUES 
    ('Aeroporto Humberto Delgado', 100, 1),
    ('Aeroporto Francisco Sa Carneiro', 200, 2),
    ('Adolfo Suarez Madrid-Barajas', 100, 3),
    ('Aeroporto El Prat', 200, 4),
    ('Aeroporto de Sevilha', 100, 5),
    ('Charles de Gaulle', 200, 6),
    ('Lyon-Saint Exupery', 100, 7),
    ('Marselha Provence', 200, 8),
    ('Fiumicino', 100, 9),
    ('Malpensa', 200, 10),
    ('Linate', 100, 10),
    ('Marco Polo', 200, 11),
    ('Berlim-Brandenburgo', 100, 12),
    ('Frankfurt (FRA)', 200, 13),
    ('Munich Airport', 100, 14),
    ('Heathrow', 200, 15),
    ('Manchester Airport', 100, 16),
    ('Liverpool (LPL)', 200, 17),
    ('Pudong (PVG)', 100, 18),
    ('Daxing (PKX)', 200, 19),
    ('Shenzhen Bao an (SZX)', 100, 20),
    ('Aeroporto de Narita (NRT)', 200, 21),
    ('Aeroporto de Narita (NRT)', 100, 22),
    ('Kobe (UKB)', 200, 23),
    ('Aeroporto Nacional Ronald Reagan Washington', 100, 24),
    ('Newark (EWR)', 100, 25),
    ('Bob Hope Airport (BUR)', 200, 26),
    ('Aeroporto Internacional de Miami', 100, 27),
    ('Pearson (YYZ)', 200, 28),
    ('Vancouver (YVR)', 100, 29),
    ('Guarulhos (GRU)', 200, 30),
    ('Santos Dumont (SDU)', 100, 31),
    ('Brasilia (BSB)', 200, 32),
    ('Benito Juarez (MEX)', 200, 33),
    ('Cancun (CUN)', 100, 34),
    ('Aeroparque Jorge Newbery (AEP)', 200, 35),
    ('Aeroporto Internacional do Cairo', 100, 36),
    ('Cape Town (CPT)', 200, 37),
    ('OR Tambo (JNB)', 100, 38),
    ('Hosea Kutako (WDH)', 200, 39),
    ('Aeroporto 4 de Fevereiro (LAD)', 100, 40),
    ('Catumbela (CBT)', 200, 41),
    ('Aeroporto Internacional da Mukanka', 100, 42),
    ('Aeroporto Internacional Welwitschia Mirabilis', 200, 43);

INSERT INTO companhias (nome, precoCompanhias, id_paises) VALUES 
    ('TAP Air Portugal', 250, 1),
    ('TAAG', 200, 1),
    ('Emirates', 250, 2),
    ('TAAG', 200, 2),
    ('TAAG', 200, 3),
    ('Air France', 250, 3),
    ('ITA Airways', 250, 4),
    ('TAAG', 200, 4),
    ('TAAG', 200, 5),
    ('Emirates', 250, 5),
    ('TAAG', 200, 6),
    ('British Airways', 250, 6),
    ('TAAG', 200, 7),
    ('Air China', 250, 7),
    ('TAAG', 200, 8),
    ('Emirates', 250, 8),
    ('Delta', 250, 9),
    ('TAAG', 200, 9),    
    ('Air Canada', 250, 10),
    ('TAAG', 250, 10),
    ('GOL', 250, 11),
    ('TAAG', 200, 11),
    ('TAAG', 200, 12),
    ('Aeromexico', 250, 12),
    ('TAAG', 200, 13),
    ('Aerolíneas Argentinas', 250, 13),
    ('TAAG', 250, 14),
    ('EgyptAir', 250, 14),
    ('South African Airways', 250, 15),
    ('TAAG', 200, 15),
    ('TAAG', 200, 16),
    ('FlyNamibia', 250, 16),
    ('TAAG', 200, 17);



SELECT 
    h.nome AS hotel,
    c.nome AS cidade,
    p.nome AS pais
FROM hoteis h
JOIN cidades c ON h.cidades_id = c.id
JOIN paises p ON c.pais_id = p.id;

SELECT 
    cidades.nome AS cidade,
    paises.nome AS pais
FROM cidades
JOIN paises ON cidades.pais_id = paises.id;


SELECT 
	r.id, c.nome AS Cliente, p.nome AS Pais, ci.nome AS Cidade,
	h.nome AS Hotel, cp.nome AS Companhia, r.classe, r.dias, r.pessoas, 
	r.total_preco, r.data_viagem, r.data_retorno
FROM reservas r
JOIN clientes c ON r.cliente_id = c.Id_Cliente
JOIN paises p ON r.pais_id = p.id
JOIN cidades ci ON r.cidade_id = ci.id
JOIN hoteis h ON r.hotel_id = h.id
JOIN companhias cp ON r.companhia_id = cp.id;


SELECT * FROM clientes;

-- DROP TABLE clientes;