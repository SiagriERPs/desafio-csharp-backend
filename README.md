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

Principais:

## Hardcoded Keys e Tokens
Atualmente os tokens do spotify estão todos presentes no código, o que alem de ser má prática para repositórios abertos, torna dificil o trabalho em equipe em um projeto real.
- Motivo: Dificuldades com a API do Spotify
- Soluções:
  1. Mudar a API 
    O serviço do SoundClound oferece uma api que seria bem melhor nesse _usecase_, porém atualmente a inscrição para a chave está fechada.
  2. Corrigir a implementação
    O spotify oferece forma de redirecionamento para autenticação, o que é longe de ótimo para consumo de apis, mas já é melhor. Porém, tive dificuldades com a implementação, em situação de maior tempo isso pode ser resolvido.

## Dispesão e mistura entre domínio e infra
- Motivo: falta de adaptação com o modelo de serialização do C#
- Solução:
  Reorganizar os modelos e entidades e fazer a Separation of Concerns mais estritamente, inicialmente as classes eram mais genericas (o que é bom), porém não funcionou bem com o mecanismo de D.I do framework

## Testes
- Os testes de unidade foram feitos (commit: de7e1165ece292fa09e66fa6c1642b1827eb2b77), porém apos me perder na serialização, eles tiveram que ser removidos.
- Solução: refatoração, os testes são importantes pedaços de documentação e devem ser mantidos.

# Como rodar a API

Por praticidade (apesar de ser uma falha), os Secrets, Key e Tokens estão todos _hardcoded_.
Devido a natureza do PS, não ocultei as keys. Porém caso elas estejam expiradas no momento da execução, elas podem ser adicionadas no caminho `Infrastructure/Services`, e substituir com suas proprias keys para ver a api em funcionamento. 
Mais detalhes nos issues. 
Apos isso é so rodar o container e executar normalmente o ambiente.



## Esclarecimentos

Como informado, fiquei doente e em estado de repouso (ainda estou). Dado isso, eu quis entregar já o resultado funcional, mesmo que esteja fora da qualidade que prezo para não haver mais atrasos e também para que eu possa ter um repouso mais despreocupado. Peço desculpas por tais fatores.

\
\
\


### Agradeço pela oportunidade, e apesar da familiaridade estar enferrujada nas tecnologias usadas
### o exercício foi bastante divertido!




