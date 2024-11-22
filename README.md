## Desafio proposto para Global Solutions 2024

O desafio deste semestre tem como tema central a Energia para um Futuro Sustentável. O evento desafia os 
participantes a pensarem em soluções tecnológicas e modelos de negócios que não apenas enfrentem os problemas 
energéticos atuais, mas também promovam justiça social, crescimento econômico sustentável e preservação ambiental.


## Ideia

Nosso projeto propõe uma solução para garantir energia de forma sustentável e acessível para todos. A ideia é criar
um aplicativo onde os usuários podem vender e comprar energia de forma simples e direta, como se fosse um mercado
livre para energia, onde o usuário publica um anúncio e outro usuário pode fazer o pagamento para adquirir esse
anúncio.
 
Essa ideia permite que pessoas que produzem energia (por exemplo, painéis solares) possam vender o excedente para
quem precisa, contribuindo para preservação do ambiente e o crescimento econômico sustentável.


## Requisitos Funcionais 

- cadastro, login, listagem, atualização e exclusão de dados dos usuários.
- cadastro, listagem, atualização e exclusão de dados referente aos anúncios.
- cadastro, listagem, atualização e exclusão de dados referente aos pagamentos.

## Requisitos Não Funcionais

- A aplicação deve ser responsiva e fácil de usar.
- Garantir a segurança de dados dos usuários.



## Sobre o Código

É levado em conta no projeto a utilização de uma arquitetura limpa para separar as responsabilidades, dessa forma
facilita a manutenção e o teste do código. A camada Models contém as classes necessárias para o projeto e suas
regras de negócio, a camada DTOs contém classes necessárias para isolar informações da camada Models, garantindo 
que não ocorra a exposição desnecessária das entidades, a camada Persistence contém a configuração do DbContext,
a camada Migrations contém o mapeamento das tabelas para o banco de dados, a camada Repositories contém os 
repositórios que conversam com o banco de dados, cada classe tem uma interface repository com seus métodos para 
que dessa forma não ocorra o contato direto das classes controllers com as classes que conectam ao banco de 
dados, e a camada controller contém os métodos HTTPs com suas operações estabelecidas para cada uma das suas 
entidades.


## Domínio

As principais entidades do domínio são:

- **Endereco** armazena informações do endereço relacionada ao usuário.
- **Usuario** representa os usuários do projeto e seus atributos.
- **Anuncio** contém os detalhes dos anúncios feitos pelos usuários.
- **Pagamento** contém os atributos necessários referente aos pagamentos executados pelos usuários.


## Classes Implementadas

- **Usuario** contém os atributos para os usuários, definindo os que são Required e validando alguns de seus dados.
- **Endereco** gerencia os dados dos endereços, além disso, é feita a validação do cep, onde apenas os números são
considerados e é verificado se o tamanho está adequado ao padrão.
- **Anuncio** detalha as informações dos anúncios.
- **Pagamento** contém os atributos necessários para as informações de pagamento.
- **LoginUsuario** criada para efetuar o login do usuário sem a necessidade de manipular toda a classe usuario
e seus atributos.
- **UsuarioDTO** criados para operações como listagem e atualização de dados, onde a certos atributos que não 
devem aparecer ou serem alterados.
- **Repository** as 3 repositories foram criadas para conversar com suas tabelas no banco de dados, permitindo
assim as operações para suas classes.
- **InterfacesRepositories** as interfaces criadas para cada classe repository tem o intuito de trazer mais 
segurança ao código, já que com elas é possível que a camada controllers não se relacione diretamente com as 
classes que chamam o banco de dados, é necessário ressaltar o dever de passar essa informação ao program.cs 
para que assim toda vez que a interface for chamada a repository relacionada a ela seja acionada. OBS: optamos
por fazer essa ação diretamente no program.cs ao invés de criar uma camada extension por conta de não haver
muitas classes repositories no código.
- **Controllers** as controllers para cada classe segue cada uma com suas operações CRUD e seus métodos HTTP, as
operações e métodos criados foram estabelecidos nos requisitos funcionais do projeto.



## Instruções de Instalação e Configuração

**1 - Primeiro Passo** - No entregável constará tanto o link do repositório no github com o projeto como o 
arquivo do projeto, caso opte pelo link do github, clone o repositório.

**2 - Segundo Passo** - Configurar a string de conexão do seu banco de dados Oracle no arquivo appsettings.json.

**3 - Terceiro Passo** - Restaurar as dependências do projeto, através do comando 'dotnet restore' na aba do 
terminal.

**4 - Quarto Passo** - Execute o comando para aplicar as migrations, dessa forma você criará ou atualizará suas 
tabelas no banco de dados oracle conforme foi estabelecido no projeto.

**5 - Quinto Passo** - Rodar a aplicação.