## Título do Projeto:

2º Projeto de Linguagens de Programação I 2018/2019 - *Zombie Simulator*

### Autores:

*[João Rebelo - a21805230](https://github.com/JBernardoRebelo)*

*[Miguel Fernández - a21803644](https://github.com/MizuRyujin)*

*[Tomás Franco - a21803301](https://github.com/ThomasFranque)*

### Repositório Git:

*[ZombieSimLP1](https://github.com/ThomasFranque/ZombieSimLP1)*

### Quem fez o quê:

`João:` Criação de classes, *Render* (alguns métodos desta), 
Agents (Lógica e movimento inicial dos agentes e *AI*, *CheckAgents*), 
Humans, Zombies, Songs, Documentação (*Readme*, Fluxogramas).

`Miguel:` Listas, implementação de interfaces, lógica de movimento, 
criação e impressão do mapa continuação e conclusão de movimento dos 
agentes e *Gameloop*.

`Tomás:` Criação de classes, *Gamesettings*, *Save Files*, *AI*, cores,
*Render*, lógica.


## Descrição da Solução:

### Arquitetura da Solução

Para resolver o problema do movimento começámos por 
colocar os agentes controlados por humanos a funcionar para 
posteriormente ser mais simples de automatizar este movimento 
com o *AI*, a compreensão da grelha toroidal foi essencial 
para o funcionamento do movimento, pois o movimento é que cria 
o funcionamento da grelha própriamente dita, isto é, o agente se quiser 
ultrapassar o `X` máximo, este, volta para o `X` mínimo e assim sucessivamente 
consoante as coordenadas de cada agente e para onde este se quer mover.
A grelha foi impressa no ecrã a partir de um ciclo *for*. Dentro dos espaços 
em branco (devido à normalização das posições da grelha) deixados na grelha 
preenchemos com os agentes correspondentes com os seus caractéres e posições 
respetivas, estes agentes estão guardados numa lista de agentes. Cada agente 
tem a sua posição e facção (*zombie* ou *human*) que é definida no construtor, 
na altura da criação da lista através dos argumentos de consola, ou 
aleatóriamente caso não tenham sido inseridos todos os dados necessários para 
a iniciação da simulação/jogo.
    Para o *AI*, cada agente *AI* verifica todos os agentes em seu redor, para
esta verificação utilizámos combinações do coeficiente binomal. Para o primeiro
agente da facção contrária que este encontrar, com base na sua própria facção,
este vai-se aproximar ou afastar.

### Diagrama UML

![](UMLZombieSim.png)

### Fluxograma

![](FluxogramZombieSim.png)

### Conclusões

Aprendemos a organizar classes de uma forma mais eficiente do que em projetos
anteriores, isto reduziu a quantidade de classes e garantiu a encapsulação
das mesmas.
Aprendemos a criar mapas eficientemente (sem criações de *arrays*) e a mais
facilmente manusear listas (estas contendo agentes a serem impressos no mapa).
Dado a conclusão da fase extra deste projeto também aprendemos a escrever/ler/
guardar ficheiros em c#.
Bases de *AI* e *pathfinding*.

### Referências

- Discussões com o Professor Fachada.

*Webgrafia*:
- *[Stack overflow](https://stackoverflow.com/)*

- *[.NET API](https://docs.microsoft.com/en-us/dotnet/api/?view=netcore-2.2)*
  
*Bibliografia*:
- *StarBound Software - The c# Players Guide ; 3rd Edition*