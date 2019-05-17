USE [CONTEC]
GO

/****** Object:  StoredProcedure [dbo].[P_CADASTRA_CLIENTE]    Script Date: 17/05/2019 12:16:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[P_CADASTRA_CLIENTE]( --[P_CADASTRA_CLIENTE] 'Teste', 'Test', '46282096000056', '23', '', '98651248', 'teste@teste.com.br', 'Avenida', 'Luis Humberto', '587', '', '06145894', 'Jd Aurora', 'Osasco', 'SP'
	@RazaoSocial VARCHAR(100),
	@NomeFantasia VARCHAR(50),
	@CNPJ VARCHAR(50),
	@DDD CHAR(2),
	@TelefoneCorporativo VARCHAR(10),
	@TelefoneCelCorporativo VARCHAR(10),
	@Email VARCHAR(50),
	@Logradouro VARCHAR(20),
	@Endereco VARCHAR(100),
	@Numero VARCHAR(4),
	@Complemento VARCHAR(100),
	@CEP VARCHAR(20),
	@Bairro VARCHAR(30),
	@Cidade VARCHAR(30),
	@UF CHAR(2)
) AS
BEGIN

	--DEFINE AS VARIAVEIS DE PK E VERIFICA SE EXISTE UM CLIENTE COM O MESMO CNPJ OU RAZAO SOCIAL
	DECLARE @ContadorClie INT = CASE WHEN NOT EXISTS (SELECT ID FROM CLIENTES) THEN 1 ELSE (SELECT MAX(ID) + 1 FROM CLIENTES) END,
	 @ContadorContatos INT = CASE WHEN NOT EXISTS (SELECT ID FROM CLIENTES) THEN 1 ELSE (SELECT MAX(ID) + 1 FROM CONTATOS_CLIENTES) END,
	 @ContadorEndereco INT = CASE WHEN NOT EXISTS (SELECT ID FROM CLIENTES) THEN 1 ELSE (SELECT MAX(ID) + 1 FROM ENDERECO_CLIENTES) END,
	 @AUX_CNPJ VARCHAR(50) = (SELECT CNPJ FROM CLIENTES WHERE CNPJ = @CNPJ),
	 @AUX_RazaoSocial VARCHAR(100) = (SELECT RazaoSocial FROM CLIENTES WHERE CNPJ = @CNPJ)
		

	BEGIN TRY
		IF ISNULL(@AUX_CNPJ,'') <> @CNPJ OR ISNULL(@AUX_RazaoSocial,'') <> @RazaoSocial
		BEGIN
			--SEGURA TRANSAÇÃO
			BEGIN TRAN
				INSERT INTO CLIENTES
				VALUES(@ContadorClie, TRIM(@RazaoSocial), TRIM(@NomeFantasia), TRIM(@CNPJ));

				INSERT INTO CONTATOS_CLIENTES
				VALUES(@ContadorContatos, TRIM(@DDD), TRIM(@TelefoneCorporativo), TRIM(@TelefoneCelCorporativo), TRIM(@Email), @ContadorClie);

				INSERT INTO ENDERECO_CLIENTES
				VALUES(@ContadorEndereco, TRIM(@Logradouro), TRIM(@Endereco), TRIM(@Numero), TRIM(@Complemento), TRIM(@CEP), TRIM(@Bairro), TRIM(@Cidade), TRIM(@UF), @ContadorClie);
			COMMIT TRAN;
		END
		ELSE
		BEGIN
			--RETORNO DO ERRO
			SELECT 'Erro'
		END
	END TRY
	BEGIN CATCH
		ROLLBACK;
	END CATCH
END
GO

