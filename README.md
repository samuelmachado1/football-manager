# Backend para gerenciar times de futebol

## Os dados devem ficam armazenados na memória.

### IncluirTime

Realiza a inclusão de um novo time.

- `long` `id`* Identificador do time
- `string` `name`* Nome do Time
- `DateTime` `dataCriacao`* Data de criação do time
- `string` `corUniformePrincipal`* Cor do uniforme principal do time
- `string` `corUniformeSecundario`* Cor do uniforme secundário do time

### IncluirJogador

Realiza a inclusão de um novo jogador.

- `long` `id`* Identificador do Jogador
- `long` `teamId`* Identificador do time
- `string` `name`* Nome do Jogador
- `DateTime` `birthDate`* Data de nascimento do Jogador
- `int` `skillLevel`* Nível de habilidade do jogador (0 a 100)
- `decimal` `salary`* Salário do jogador

### DefinirCapitao

Define um jogador como capitão do seu time. Um time deve ter apenas um capitão, por tanto o capitão anterior voltará a ser apenas jogador.

- `long` `playerId`* Identificador do jogador.

### BuscarCapitaoDoTime

Mostra o `id` do capitão do time.

- `long` `teamId`* Identificador do Time

### BuscarNomeJogador

Retorna o `name` do jogador.

- `long` `playerId`* Identificador do jogador

### BuscarNomeTime

Retorna o `name` do time.

- `long` `teamId`* Identificador do Time

### BuscarJogadoresDoTime

Retorna a lista com o `id` de todos os jogadores do time, ordenada pelo `id`.

- `long` `teamId`* Identificador do Time

### BuscarMelhorJogadorDoTime

Retorna o `id` do melhor jogador do time. Utilizar o menor `id` como critério de desempate.

- `long` `teamId`* Identificador do time.

### BuscarJogadorMaisVelho

Retorna o `id` do jogador mais velho do time. Usar o menor `id` como critério de desempate.

- `long` `teamId` * Identificador do time

### BuscarTimes

Retorna uma lista com o `id` de todos os times cadastrado, ordenada pelo `id`.
Retornar uma lista vazia caso não encontre times cadastrados.

### BuscarJogadorMaiorSalario

Retorna o `id` do jogador com maior salário do time. Usar o menor `id` como critério de desempate.

- `long` `teamId`* Identificador do time.


### BuscarSalarioDoJogador

Retorna o `salário` do jogador.

- `long` `playerId`* Identificador do jogador


### BuscarTopJogadores

Retorna uma lista com o `id` dos `top` melhores jogadores, utilizar o menor `id` como critério de desempate.

- `int` `top`* Quantidade de jogares na lista

### BuscarCorCamisaTimeDeFora

Retorna a cor da camisa do time adversário. 

- `long` `teamId`* Identificador do time da casa
- `long` `visitorTeamId`* Identificador do time de fora


## Requisitos

- .NET Core 2.0+
- Visual Studio ou Visual Studio Code


**Desafio desenvolvido por Samuel Machado no programa de aceleração em C# da Codenation patrocinado pela Wiz Soluções.**

