# ManageBidding
Aplicação web que permite aos usuários gerenciar e acompanhar licitações.

# Criando banco de dados e tabelas

Para criar o banco de dados e tabelas há duas opções: 

1. **Migration**
    - Abrir o Package Manager Console no Visual Studio.
    - Selecionar o Default Project: **ManageBidding.Data**
    - Executar o comando: **update-database**
    
2. **Executando scripts**
    
    Na pasta raíz do projeto existe uma pasta chamada **sql** com todos os scripts.
    
    - Executar o script de criação do banco de dados: **1.CREATE_DATABASE_ManageBidding**
    - Executar o script de criação das tabelas: **2.CREATE_TABLE_Biddings.sql**
