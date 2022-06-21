##### ESY test for submitting job
Firstly change database credentials in `project folder\Web.config`

`<add name="DefaultConnection" providerName="MySql.Data.MySqlClient" connectionString="Datasource=localhost;Database=esy;uid=root;pwd=;"/>`

##### Warning: Dont create database! It will create automatically by migration. 

`You can run project in Visual studio by clicking F5`

###### Project Url -  http://localhost:58249/

You can change VAT value in `project folder\Web.config` 

##### Default login credentials
`Login: admin@admin.com, password: 123456`

`<add key="VAT" value="12"/>`

You can get Product Audits by get request `http://localhost:58249/Home/Audit` as JSON data

#### Used technologies

- Database: Mysql
- Language: C# ASP .NET;
- EntityFramework;



#### Copyright by - Doston Rakhmatov
