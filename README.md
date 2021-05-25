# Blue Modas Store

Projeto teste de um E-commerce básico para uma loja fictícia chamada Blue Modas.

O projeto foi desenvolvido em 3 camadas: 

- BlueModasStore              
  > Camada de apresentação que compreende o projeto Angular 8 dentro da pasta ClientApp.
- BlueModasStore.Domain       
  > Camada de domínio, onde ficam as interfaces e services necessários para a aplicação.
- BlueModasStore.Infra        
  > Camada de infra, onde são implementados os repositórios descritos nas interfaces da camada de domínio.

## Instalação

O projeto foi criado em **ASP.NET Core 3.1** e **Angular 8** utilizando **Visual Studio 2019** versão 16.6.3. 
Para o banco de dados foi utilizado o **Sql Server 2016 Express Edition**.

Para testar o projeto, clone o repositório e abra o arquivo **BlueModasStore.sln** no Visual Studio.

Dentro do projeto BlueModasStore existe um diretório chamado **BackupSql** com um banco populado chamado BlueModas.bak. 
Restaure esse arquivo no Sql Server.
  > Para simplificação, foi adicionado 6 produtos no banco de dados, e suas imagens estão armazenadas dentro da pasta *ClientApp/src/assets/images*.
  
Execute o projeto.

## License
[MIT](https://choosealicense.com/licenses/mit/)
