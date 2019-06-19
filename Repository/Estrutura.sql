DROP TABLE recebidas;

CREATE TABLE recebidas(
	id INT PRIMARY KEY IDENTITY(1,1), 
	nome VARCHAR(100),
	valor DECIMAL(16,2),
	tipo VARCHAR(100),
	descricao VARCHAR(100),
	status VARCHAR(100),
);


CREATE TABLE contas_a_pagar(
	id INT PRIMARY KEY IDENTITY(1,1), 
	nome VARCHAR(100),
	valor DECIMAL(16,2),
	tipo VARCHAR(100),
	descricao VARCHAR(100),
	status VARCHAR(100),
)

CREATE TABLE clientes_pf(
	id INT PRIMARY KEY IDENTITY(1,1), 
	nome VARCHAR(100),
	cpf VARCHAR(100),
	data_nascimento DATETIME2,
	rg VARCHAR(100),
	sexo VARCHAR(100),
);

CREATE TABLE endereco(
	id INT PRIMARY KEY IDENTITY(1,1), 
	unidade_federativa VARCHAR(100),
	cidade VARCHAR(100),
	lagradouro VARCHAR(100),
	cep VARCHAR(100),

);
SELECT * FROM recebidas
INSERT INTO recebidas (nome, valor, tipo, descricao, status) VALUES ('lalala', 20, 'lalala', 'descricao', 'pago');
