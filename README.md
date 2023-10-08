# DesafioDSV
*Sobre o projeto*
Projeto criado em .Net 6.0 para leitura e inserção no banco de dados de uma planilha que contém duas abas, de Clientes e Débitos.
Projeto foi desenvolvido com Windows Form, onde a conexão é feita diretamente através dele, contendo campos para definir o SERVER, DATABASE, USERID e PASSWORD.
*Sobre a planilha*
planilha obrigatoriamente precisa estar no formato .xlsx
Para a aba de Clientes, devem conter as seguintes informações: ID, Nome, Cidade, UF, CEP, CPF.
Para a aba de Debitos, devem conter as seguintes informações: Fatura, Código do Cliente, Data de Emissao, Data de Vencimento, Valor, Juros, Descontos, Data de Pagamento, Valor Pago
*Como utilizar o projeto*
Obrigatoriamente necessário ter o SQL SERVER instalado na máquina para utilizar o programa.
O script para criação do banco de dados está disponível no repositório, basta executá-lo antes de rodar o projeto.
No projeto, temos Três botões Inserir no banco, Testar conexão e buscar. Recomendado preencher todos os campos de Conexão com o banco e clicar no botão de Testar Conexão para verificar se o programa estabeleceu a conexão
com seu SQL SERVER. O botão buscar, que é codificado através do openfiledialog tem como finalidade permitir que o usuário busque uma tabela em seu computador. O botão "Inserir no Banco", realiza a inserção das informações
da planilha especificada pelo usuário no banco de dados.
(Todos os campos estão sendo validados, então se por ventura não preencher um deles, o programa não realizará a operação de inserção no banco)
