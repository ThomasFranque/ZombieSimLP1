# Notas e Planeamento

## Função de cada class inicial

### Render

Imprime elementos na consola.

### Map

Chama `Render` e imprime mapa.

### MapCreator

Verifica se ba posição do `for` envia um _human_ ou _zombie_.

### Agents

Características dos agentes e movimento! (`is`...).

### Zombies

Infetam agentes !infected.

### Humans

Normal agent (...).

### IA

Automatização do jogo/movimentos de personagens retornando posições aleatórias.

### AgentCheck

Retorna _True_ ou _False_ verificando os obstáculos (agentes no caminho).

## Notas / Pensamentos

1. Infeção = Verificar posição através de `is`.
2. AI verifica quais os movimentos possíveis, mover para posição aleatória com base nisso.
3. AI, percorre listas.
4. 2 Tipos de lista - _automated_ && - _playable_
5. 1 Percorrer listas _automated_ enquanto houver _zombies/humans_ para mexer em casa turno.
6. 2 Percorrer listas _playable_ enquanto houver _zombies/humans_ para o jogador mexer (caso existam).

## Brainstorm Inicial

- Turn Based
- Grelha toroidal
- Array current pos
- Array agents, ID
- Inverted checker, "what can't the AI do"
- Posições individuais
- Class static (render?)
- Turn - GameLoop
- Ends game when all _NPCs_ are zombies or turns < 0
- FASE EXTRA
- Fase 2 <-- se houver tempo, Fase 3
- Bool check position (?)
- Players move all humans/zombies available per turn
- Board struct
- TryParse
- Try Catch at start of program
- Time counter