# Detalhes

O projeto foi feito com bases de DDD e Clean Architecture (apesar que alguns detalhes do "MVP" estão incorretos). E as seguintes metodologias foram utilizadas

* Observer pattern (Pode ser visto na pasta de Framework proprio em `Entity`)
* Conventional Commits (Por isso não há flexão temporal nos verbos dos commits) [Documentação](https://www.conventionalcommits.org/en/v1.0.0/)
* Dependency Inversion Principle 
* Domain Services / Contract Programming
* Separation of Concerns 
* EventStorming para organização das ideias [Ver no Miro](https://miro.com/app/board/o9J_l6XmmXU=/)



# Comentários 

Essa foi minha primeira vez implementando esse tipo de serviço em C#/.NET, e vindo de linguagens como Dart e Elixir, me "embananei" bastante com a forma de serialização nos estágios finais da api. O que prejudicou bastante a implementação do dominio. Nos commits pode ser observado o quanto foi organizado o até chegar no estado _MVP_ que ficou mais disperso.
 * No issues deixarei explicito minhas falhas e formas de solucionar elas



# Como rodar a API

Por praticidade (apesar de ser uma falha), os Secrets, Key e Tokens estão todos _hardcoded_.
Devido a natureza do PS, não ocultei as keys. Porém caso elas estejam expiradas no momento da execução, elas podem ser adicionadas no caminho `Infrastructure/Services`, e substituir com suas proprias keys para ver a api em funcionamento. 
Mais detalhes nos issues. 
Apos isso é so rodar o container e executar normalmente o ambiente.



## Esclarecimentos

Como informado, fiquei doente e em estado de repouso (ainda estou). Dado isso, eu quis entregar já o resultado funcional, mesmo que esteja fora da qualidade que prezo para não haver mais atrasos. Peço desculpas por tais fatores.




