# Sample API with WebAPI

Para desenvolver este exemplo utilizei o WebAPI 2 .net. Usei uma arquitetura no estilo OnionLayers e a API foi desenvolvida usando tecnicas de TDD, sendo todas funções e classes da API cobertas pelos teste (a escrita e leitura do banco de dados pôde ser testada atravês de uma classe Mock de repositório). Já para a camada de armazenamento de dados utilizei o LiteDB que é um banco de dados "MongoDB-like" e compacto (http://www.litedb.org/).  Para testar o ClientAPI execute os testes unitários ou então utilize um app como o Postman (https://www.getpostman.com/).
