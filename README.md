
# *Softplayer* 
 * [Guidelines](#guidelines)
 * [Instalação](#instalação)
 * [APIs](#apis)
	 * [Management Interest Api](#management-interest-api)
	      * [Controllers](#controllers)
	           * [Interest](#interest)
	                * [Obter Taxa de Juros v1.](#obter-taxa-de-juros-v1)
	 * [Accounting.Api](#accounting.interest.api)
	      * [Controllers](#controllers)
	           * [Interest](#interest)
	                * [Calcula Juros Compostos v1.](#calcula-juros-compostos-v1)
	                * [Mostra Código Fonte v1.](#mostra-código-fonte-v1)
----

## **Guidelines**

Este documento provê um tutorial de instalação e os endpoints das Apis.

## **Instalação**
#### Modo debug
 1. Clonar o [repositório](https://github.com/businessclaudinei/softplayer.git): git clone https://github.com/businessclaudinei/softplayer.git
 2. Abra o diretório softplayer
 3. Executar o arquivo em Redis/redis-server.exe
 4. Executar o arquivo em src\Accounting.Interest\Accounting.Interest.sln
 5. Rodar o projeto Accounting.Interest.Api
 6. Executar o arquivo em src\Management.Interest\Management.Interest.sln
 7. Rodar o projeto Management.Interest.Api
 8. Abrir o browser no endereço http://localhost:5001/swagger

#### Modo Docker
	

 - Necessário ter [Docker Desktop for Windows](https://www.docker.com/products/docker-desktop)
 - Selecionar a opção para rodar Docker para containers Linux
 

    **$ cd src
    $ docker-compose build
    $ docker-compose -f docker-compose.yml up**

 - Acessar a url http://localhost:8001/swagger

----
## *APIs* 
## *Management Interest Api* 

### **Controllers**
---
#### Interest
---
##### Obter Taxa de Juros v1

- [ *GET* taxa-juros ]

	- **Description:** Este método é responsável por obter a taxa de juros. A resposta deste método contém a taxa de juros.

	- **Requirements:**   
            Nenhum.  

	- **Dependencies:**  
            Access to Redis

	- **Request:**

		```json
		{}
		```
	- **Response:**

	   * *200 - OK*           
		```json 
		{
           "interestRate": 0,
           "currencyCode": "string"
        }
		```
              
         * *500 - INTERNAL SERVER ERROR*           
		```json 
		{
          "data": {},
          "notification": {
          "responseCode": "500",
          "message": "string",
          "details": {},
          "invalidFields": [
            {
              "fieldName": "string",
              "message": "string"
            }
           ]
          }
        }
		```
		---

----
## *Accounting.Interest.Api v1* 

### **Controllers**
---
#### Interest
---
##### Calcula Juros Compostos v1

- [ *POST* calcula-juros ]

	- **Description:** Este método calcula os juros compostos a partir de uma taxa de juros. A resposta do metodo contém o calculo dos juros compostos.  
***Nota, o parametro [principal] e [timeInMonths] são obrigatórios.***

	- **Requirements:**   
            Nenhum.  

	- **Dependencies:**  
            Acesso ao Redis para cache
            Acesso ao endpoint [/taxa-juros.](#obter-taxa-de-juros-v1) da api [Management.Interest.Api](#management-interest-api)

	- **Request:**

		```json
		{
          "timeInMonths": 0,
          "principal": 0
        }
		```
	- **Response:**

	   * *200 - OK*           
		```json 
		{  
		   "compoundInterestAmount":  0,  
		   "currencyCode":  "string"  
		}
		```
              
         * *400 - BAD REQUEST*           
		```json 
		{
          "data": {},
          "notification": {
          "responseCode": "400",
          "message": "string",
          "details": {},
          "invalidFields": [
            {
              "fieldName": "string",
              "message": "string"
            }
           ]
          }
        }
		```
         * *500 - INTERNAL SERVER ERROR*           
		```json 
		{
          "data": {},
          "notification": {
          "responseCode": "500",
          "message": "string",
          "details": {},
          "invalidFields": [
            {
              "fieldName": "string",
              "message": "string"
            }
           ]
          }
        }
		```
		---
##### Mostra Código Fonte v1

- [ *GET* show-me-the-code ]

	- **Description:** Este método é responsável por apresentar o código fonte no GitHub. A resposta do método é a url do repositório Github.

	- **Requirements:**   
            Nenhum.  

	- **Dependencies:**  
            Nenhuma.

	- **Request:**

		```json
		{}
		```
	- **Response:**

	   * *200 - OK*           
		```json 
		{  
		  "gitHubRepositoryUrl":  "string"  
		}
		```
             
         * *500 - INTERNAL SERVER ERROR*           
		```json 
		{
          "data": {},
          "notification": {
          "responseCode": "500",
          "message": "string",
          "details": {},
          "invalidFields": [
            {
              "fieldName": "string",
              "message": "string"
            }
           ]
          }
        }
		```
		---
