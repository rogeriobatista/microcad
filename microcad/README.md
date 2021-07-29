#########################################################

<P>TOPOCAD2000 API
<P>Versao 1.10
<P>2020-12-26
<P>PIERRE BALOCHINI pbal@backware.com.br +55-21-985350565
<P>Release 0 1 2 3 4 5
#########################################################

Changelog:

Versao 1.0 - Prototipo basico da API - 2020-12-21

Versao 1.1 - Adicionado as Rotas Diversas - 2020-12-26

Esta API tem por objetivo fazer a gestao de licencas dos usuarios.

Funcoes Basicas:

01 - Verificacao da API esta on-line

https://host:port
serve para ver se a API esta rodando.

Metodo: GET

exemplo:

https://host:port

      retorna o texto "API is up and running..."

02 - Verificacao do Serial do Cliente

https://host:port/checklicense/nserie
serve para consultar o numero de serie da licensa e retorna os dados no formato json.

Metodo: GET

exemplo com sucesso:

https://host:port/checklicense/123456

{
"nserie": "123456",
"tipo": "F",
"versao": "V15",
"email": "pbal@backware.com.br",
"cliente": "Pierre Charles Balochini",
"cgc": "84549017791"
}

exemplo sem sucesso:

https://host:port/checkstatus/99999

{}

03 - Atualiza/Cria licença

https://host:port/updatelicense

     Atualiza um registro existente ou cria um novo e retorna todos os campos.

     Metodo: POST

     Body:
     {
         "nserie": "T25995",
         "tipo": "B",
         "versao": "V16",
         "email": "felixjm@topocad.com.br",
         "cliente": "FELIX MELO 2",
      	"cgc": "12345678901"
      }

      Retorna os campos do registro atualizado.

04 - Listagem do Banco de Dados

https://host:port/listlicense
listagem de todos os registros da tabela TBLRegistro

Metodo: GET

05 - Numero de Registros

https://host:port/countlicense

     Retorna o numero de licenças da tabela TBLRegistro.

Metodo: GET

06 - Apagar Licença

https://host:port/deletelicense/nserie
serve para apagar um registro da TBLRegistro informando o nserie a ser excluido.

Metodo: DELETE

exemplo com sucesso:

{1}
