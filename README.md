# Rental Notebook API ##

# Descrição

Uma simples API feita em ASP.NET utilizando C#

## Pacotes utilizados:
```html
$ Install-Package Microsoft.EntityFrameworkCore.SqlServer
$ Install-Package Microsoft.EntityFrameworkCore.Tools
$ Install-package Microsoft.AspNetCore.Authentication
$ Install-package Microsoft.AspNetCore.Authentication.JwtBearer
$ Install-package --version 5.5.0 Swashbuckle.AspNetCore
```
## Query SQL consulta de produtos, se está alocado com algum cliente e data prevista de devolução:
```html
SELECT
	AN.NOMELOCADOR, 
	N.NOTEBOOKS,
	AN.VALORALUGUEL,
	AN.DATADEVOLUCAO,
	CASE 
		WHEN AN.ESTAALUGADO = 1 THEN 'SIM' ELSE 'NÃO' END AS 'ESTAALUGADO'
FROM  
	ALUGARNOTEBOOKS	AN
	INNER JOIN NOTEBOOKS N ON N.ID = AN.NOTEBOOKID
```
- Consultar clientes que estão com determinado Notebook. Inserir junto da Query acima.
```html
WHERE
	N.NOTEBOOKS = 'RAZER' 
```
## Autenticação/Autorização
1.	Acesse a rota/login
2.	Insira os valores no formato JSON que estão na classe /Models/User
3.	Será gerado Token
4.	Insira no Postman para acessar a rota com autorização

 - Exemplo:
```html
{ "username": "Fagner", "password": "Fagner" }
```
 - DB Connection:
```html
(localdb)\mssqllocaldb
```