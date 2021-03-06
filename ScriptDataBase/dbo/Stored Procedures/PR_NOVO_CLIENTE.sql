-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE PR_NOVO_CLIENTE
	@NOME_CLIENTE VARCHAR(200),
	@TIPO_CLIENTE CHAR(1),
	@FANTASIA_CLIENTE VARCHAR(200) = NULL,
	@CPF_CNPJ_CLIENTE VARCHAR(18),
	@INSC_MUNICIPAL_CLIENTE VARCHAR(15) = NULL,
	@INSC_ESTADUAL_CLIENTE VARCHAR(15) = NULL,
	@FONE_CLIENTE_1 VARCHAR(15),
	@FONE_CLIENTE_2 VARCHAR(15) = NULL,
	@EMAIL_CLIENTE VARCHAR(30) = NULL,
	@CEP_CLIENTE VARCHAR(9),
	@ENDERECO_CLIENTE VARCHAR(100),
	@BAIRRO_CLIENTE VARCHAR(50),
	@CIDADE_CLIENTE VARCHAR(50),
	@UF_CLIENTE VARCHAR(2),
	@COMPLEMENTO_CLIENTE VARCHAR(20) = NULL,
	@DATA_INCLUSAO_CLIENTE DATETIME,
	@DATA_ALTERACAO_CLIENTE DATETIME = NULL,
	@NUMERO_CLIENTE VARCHAR(10) = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO CAD_CLIENTE (
		NOME_CLIENTE,
		TIPO_CLIENTE,
		FANTASIA_CLIENTE,
		CPF_CNPJ_CLIENTE,
		INSC_MUNICIPAL_CLIENTE,
		INSC_ESTADUAL_CLIENTE,
		FONE_CLIENTE_1,
		FONE_CLIENTE_2,
		EMAIL_CLIENTE,
		CEP_CLIENTE,
		ENDERECO_CLIENTE,
		BAIRRO_CLIENTE,
		CIDADE_CLIENTE,
		UF,
		COMPLEMENTO_CLIENTE,
		DATA_INCLUSAO_CLIENTE,
		DATA_ALTERACAO_CLIENTE,
		NUMERO_CLIENTE)
	VALUES (
		@NOME_CLIENTE,
		@TIPO_CLIENTE,
		@FANTASIA_CLIENTE,
		@CPF_CNPJ_CLIENTE,
		@INSC_MUNICIPAL_CLIENTE,
		@INSC_ESTADUAL_CLIENTE,
		@FONE_CLIENTE_1,
		@FONE_CLIENTE_2,
		@EMAIL_CLIENTE,
		@CEP_CLIENTE,
		@ENDERECO_CLIENTE,
		@BAIRRO_CLIENTE,
		@CIDADE_CLIENTE,
		@UF_CLIENTE,
		@COMPLEMENTO_CLIENTE,
		@DATA_INCLUSAO_CLIENTE,
		@DATA_ALTERACAO_CLIENTE,
		@NUMERO_CLIENTE);
	END