# Pokémon Challenge

1. Guia de utilização
2. Escolha de linguagem
3. Recursos e Técnologias utilizadas


### 1. Guia de utilização

* O Layout do site conta com 2 opções clicáveis, para navegar entre a página inicial e a de Procurar uma cidade. <br/>
![Tela inicial](DocImg/img1.png)

* Logo em sua primeira tela, é possível visualizar uma mensagem inicial com um grande botão abaixo, que te redireciona para uma nova janela, nomeada como SearchCity. <br/>
![Tela inicial](DocImg/Start.png)


* Nesta janela, existem 2 elementos para interação do usuário. O campo de pesquisa é responsável por receber o nome de alguma cidade no mundo, e abaixo dele, o botão "Procurar pokémon" está responsável por enviar o que o usuário deseja pesquisar. <br/>
![Tela Pesquisa](DocImg/img2.png)


* Caso o texto inserido no campo de busca retorne uma cidade válida na API do [Open Weather](https://openweathermap.org/), ele irá passar para a última tela, com a resposta esperada de acordo com a temperatura da cidade pesquisada. Caso retorne algum erro, ou então uma cidade inválida, irá retornar uma mensagem de alívio diferente na mesma tela, informando ao usuário para tentar novamente.<br/>
![Tela Pesquisa Erro](DocImg/img3.png)



* Na última janela, após uma cidade válida ser pesquisada, irá retornar algumas informações sobre a cidade, sendo elas a temperatura em Grau Celsius, se está ou não chovendo, e um pokémon possível de aparição na cidade de acordo com as informações de chuva e temperatura, após passar por uma lógica e buscar na api do [Poke Api](https://pokeapi.co/). <br/>
![Ex Whimsicott](DocImg/whimsicottResult.png)


* Caso o Pokémon retornado seja uma variação de um pokémon original da Pokédex, como o Snorlax Gmax, uma mensagem avisando sobre o Pokémon variante aparecerá, e retornará também o pokémon original da Pokédex. <br/>
	![Ex Snorlax](DocImg/exSnorlaxGmax.png)

### 2. Escolha de linguagem
<p align="justify"> Foi escolhido para este desáfio a linguagem de programação <b>C#</b> pela preferência em retomar algo antes já estudado e posto em prática. Também foram utilizados elementos de <b>HTML</b> e <b>CSS</b> para estilização e dar vida ao site.</p>

### 3. Recursos e Técnologias utilizadas
<p align="justify">Como dito anteriormente, a linguagem predominante no projeto é <b>C#</b>, auxiliado na organização pelo modelo <b>MVC</b> para melhor organização. O <b>Postman</b> foi utilizado logo no inicio para realizar os testes com a <b>API</b> do <b>Open Weather</b>, e compreende-la, posteriormente foi realizado um teste em código, e feito o primeiro progresso, retornando informações que seriam úteis em seguida para o uso da <b>API</b> do <b>Poke Api</b> após passar pela lógica de seleção do tipo de Pokémon a ser retornado.</p>