USE [CONTEC]
GO

/****** Object:  StoredProcedure [dbo].[P_UPDATE_CLIENTE]    Script Date: 17/05/2019 12:16:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[P_UPDATE_CLIENTE]( --[P_UPDATE_CLIENTE] '1', 'Teste', 'Test', '46282096000056', '23', '', '98651248', 'teste@teste.com.br', 'Avenida', 'Luis Humberto', '587', '', '06145894', 'Jd Aurora', 'Osasco', 'SP'
	@ID INT,
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

	BEGIN TRY
		--VERIFICA O ID
		IF ISNULL(@ID,'') <> ''
		BEGIN
			--SEGURA TRANSAÇÃO
			BEGIN TRAN
				--REALIZA UPDATE NAS TRÊS TABELAS
				UPDATE CLIENTES SET RazaoSocial = CASE WHEN @RazaoSocial = '' THEN RazaoSocial ELSE @RazaoSocial END, 
				NomeFantasia = CASE WHEN @NomeFantasia = '' THEN NomeFantasia ELSE @NomeFantasia END, 
				CNPJ = CASE WHEN @CNPJ = '' THEN CNPJ ELSE @CNPJ END
				WHERE ID = @ID;

				UPDATE CONTATOS_CLIENTES SET DDD = CASE WHEN @DDD = '' THEN DDD ELSE @DDD END, 
				TelefoneCorporativo = CASE WHEN @TelefoneCorporativo = '' THEN TelefoneCorporativo ELSE @TelefoneCorporativo END
				, TelefoneCelCorporativo = CASE WHEN @TelefoneCelCorporativo = '' THEN TelefoneCelCorporativo ELSE @TelefoneCelCorporativo END
				, Email = CASE WHEN @Email = '' THEN Email ELSE @Email END
				WHERE ID_CLI = @ID;

				UPDATE ENDERECO_CLIENTES SET Logradouro = CASE WHEN @Logradouro = '' THEN Logradouro ELSE @Logradouro END, 
				Endereco = CASE WHEN @Endereco = '' THEN Endereco ELSE @Endereco END
				, Numero = CASE WHEN @Numero = '' THEN Numero ELSE @Numero END
				, Complemento = CASE WHEN @Complemento = '' THEN Complemento ELSE @Complemento END
				, CEP = CASE WHEN @CEP = '' THEN CEP ELSE @CEP END
				, Bairro = CASE WHEN @Bairro = '' THEN Bairro ELSE @Bairro END
				, UF = CASE WHEN @UF = '' THEN UF ELSE @UF END
				, Cidade = CASE WHEN @Cidade = '' THEN Cidade ELSE @Cidade END
				WHERE ID_CLI = @ID;
			COMMIT TRAN;
		END
		ELSE
		BEGIN
			--RETORNA ERRO
			SELECT 'RETORNO'
		END
	END TRY
	BEGIN CATCH
		--RETORNA ERRO
		SELECT 'RETORNO'
		ROLLBACK;
	END CATCH
END
GO

