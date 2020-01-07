# workana-valmir

Comando para obter todas as tabelas do banco de dados:

Scaffold-DbContext "Data Source=VINICIUS-DELL\SQLEXPRESS;Initial Catalog=projetoTestexxx;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -Context "BackEndContext"

Necessita apenas alterar a connection string.

Isso gera os arquivos de todas as tabelas do banco de dados na pasta BackEnd.Infra.Data/DatabaseFirst.

# Models
Copie os arquivos da pasta BackEnd.Infra.Data/DatabaseFirst/Models para a pasta BackEnd.Domain/Models.

Lembre-se que toda classe deve necessáriamente extender de BaseEntity. Por exemplo: 
	public class Cargo : BaseEntity { ... }

# Context
Não recomendo copiar o arquivo de contexto localizado em BackEnd.Infra.Data/DatabaseFirst/Context para BackEnd.Infra.Data/Context.

Isso porque a connection string do projeto está localizado neste arquivo. O importante é fazer manualmente a adição dos DbSets e substituir o método OnModelCreating.

# Filters

Crie, para cada Model gerado, um filter na pasta BackEnd.Application/Filters. Tome como base o CargoFilter.cs

# ViewModels

São os objetos que vem nas requisições. Crie, para cada Model gerado, um ViewModel em BackEnd.Application/ViewModel

# Repositories
Camada que faz acesso ao banco de dados.

## Interfaces
Crie, para cada Model gerado, uma interface de repository em BackEnd.Infra.Data/Interfaces. Tome como base o ICargoRepository.

## Repositório

Crie, para cada Model gerado, uma implementação de repository em BackEnd.Infra.Data/Repositories. Tome como base o CargoRepository.

# Services
Camada de lógica de negócio.

## Interfaces
Crie, para cada Model gerado, uma interface de serviço em BackEnd.Application/Interfaces. Tome como base o ICargoAppService.

## Serviço
Crie, para cada Model gerado, uma implementaçao de serviço em BackEnd.Application/Interfaces. Tome como base o CargoAppService.

Os métodos Filter e OrderBy variam de model a model. Filter pesquisa no banco de dados e OrderBy ordena no banco de dados. Construa sua lógica de acordo com a necessidade. Há um exemplo bom em FranqueadoAppService.

# Controllers

Crie, para cada Model gerado, um Controller em BackEnd.API/Controllers. Tome como base o CargoController substituindo as váriaveis necessárias como ViewModel, Filter, Model e o service responsável pelo model.

# Injeção de Dependencia (IoC)

Altere o arquivo BackEnd.Infra.IoC/NativeInjectorBootStrapper.cs para entender os serviços e repositories criado. Basta seguir o exemplo.

# AutoMapper

Inclua a configuração de AutoMapper de Domain -> ViewModel e ViewModel -> Domain. Os arquivos são BackEnd.Application/DomainToViewModelMappingProfile.cs e BackEnd.Application/ViewModelToDomainMappingProfile.cs.

O arquivo FilterToViewModelMappingProfile é apenas para tratamento de sublistas caso haja a necessidade de realizar algum filtro depois do banco de dados ter retornado os resultados. Por exemplo: Desejo pegar os franqueados que possuem o funcionario X e, desejo que os franqueados retornem apenas ele na lista de funcionario.

Caso não tenha ficado claro a ideia de FilterToViewModelMappingProfile, siga esses passos:

1) Comente o conteudo de AfterMap de FraqueadoFilter -> FranqueadoViewModel
2) Realize a requisição GET http://localhost:3000/api/v1/api/Franqueado?IdFranqueado=2&IdFuncionario=5
3) Descomente o conteudo de AfterMap de FraqueadoFilter -> FranqueadoViewModel
4) Realize novamente a requisição GET http://localhost:3000/api/v1/api/Franqueado?IdFranqueado=2&IdFuncionario=5
5) Compare os resultados JSON
