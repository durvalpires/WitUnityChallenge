# WitUnityChallenge
Unity Challenge for Wit Software



### Utilização

Se o projecto for corrido no PC/Mac, todo o controlo é feito através do rato. Em caso de build mobile, é usando touch input.

### Estrutura

Um factor que foi fundamental para a forma como estruturei o projecto foi o facto de ter sido pedido para criar duas cenas. E como foi usada a palavra "cena", eu fiquei a achar que queria explícitamente que fossem usadas diferentes "Unity scenes" para o projecto, algo que eu executei. Apesar disso, no meu entender seria mais simples apenas uma cena com diferentes prefabs para as diferentes secções, mas nada que impedisse o projecto de ser realizado. E como é natural ao Unity, existem diferentes caminhos para executar um objectivo.

Esta mesma versatilidade inerente ao Unity fez com que eu nas diferentes cenas usasse abordagens ligeiramente diferentes ao modo de implementar, como irei explicar nos tópicos seguintes. Existem maneiras mais "editor oriented", outras mais "code oriented", e tentei fazer coisas de maneiras diferentes para cobrir diferentes abordagens (ex: Overlay UI vs World Space UI).

A base do projecto envolve o conceito de sections, que são automaticamente retiradas quando uma nova é definida no serviço. Isso facilita a implementação e organização de diferentes partes duma aplicação. Neste caso em específico, os dividendos que retirei disso foram menores porque efectuei o carregamento de cenas distintas, mas caso fosse tudo na mesma cena, esta estrutura e abordagem facilitaria imenso a implementação. Da mesma forma, normalmente dividiria cada secção entre UI e Stage (3D), sendo que neste caso apenas usei as secções para UI (devido à mesma razão descrita anteriormente).

### UI

Cada uma das cenas usa uma abordagem diferente, por opção pessoal, apenas porque pensei em usar diferentes tipos de Canvas e abordagem. Na 1ª cena, implementei UI em modo overlay, devido ao facto de, em teoria, a cena ser estática, o que faria com que os nomes pudessem estar no local correcto apesar de não estarem ligados directamente aos modelos. Porém, com as diferentes resoluções de inúmeros modelos de telemóvel isso pode não ocorrer a 100%. Ainda assim, a minha opção por esta abordagem foi por uma questão de performance, porque para usar modo overlay e ter os nomes directamente ligados aos modelos exigiria um cálculo em cada frame da world position para screen position, então, visto que queria usar em cada cena uma abordagem diferente ao UI, tentei seguir a opção mais "leve".

No modo de customização, usei UI em world coordinates, o que permitiu brincar um pouco com a perspectiva de alguns dos elementos, e dar um toque diferente. A ideia era um pouco dar um feeling de "character editor" ao ecrã, com diferentes opçãos que pudessem ser testadas de forma dinâmica e imediata. 

No entanto, nem tudo foi perfeito. Tenho de admitir que perdi a batalha com o Input Field, devido ao facto de ter escolhido World Space UI. Já tinha trabalhado inúmeras vezes com este elemento em Overlay UI, mas, como acontece com todos os elementos de texto em World Space UI, a "Unity Unit" para os caracteres torna-se gigante, o que normalmente exige reduções grandes ao nível da escala dos GameObjects. Porém, com este elemento em específico, o problema não era com o tamanho da letra mas sim com a largura do "Blinking Caret" que marca o local onde o texto está a ser editado. Esse elemento vem com um valor mínimo de "1", o que fez com que eu não o conseguisse diminuir como desejava, e admito que não encontrei nenhuma forma de solucionar esse detalhe, e como temia gastar horas de mais nesse ponto e descurar o resto do challenge, decidi seguir em frente.

Devido a toda a UI usar elementos de Imagem coloridos e texto (exceptuando um png de uma seta), não foi necessário criar um Atlas para optimizar as draw calls da UI. Na mesma linha de pensamento, devido ao espectro reduzido da UI não foi necessária a criação de diferentes Canvas.

### Extensões

Em termos de adições às capacidades nativas do Unity, foi usado DOTween para animações, TextMeshPro para texto, e modelos de 3D retirados de diferentes packs de assets gratuitos da Asset Store.

### Dados

Os dados das personagens são carregados, e guardados, em formato JSON, para que persistam após a aplicação ser fechada. No caso de não existir ficheiro para uma das personagens, ele é criado on startup, assim como os dados default dela. No que toca às diferentes animações e tipos de estilo, estas estão definidas em código, e são identificadas através de Id. Algumas classes tiveram de ser simplifacadas e deixadas com todos as variáveis public para que a library de JSON do Unity pudesse funcionar.

### Som

Toda a parte sonora (música e sound effects) do projecto foi desenvolvida por mim no Ableton Live. Apesar de não ter sido pedido no challenge, a minha paixão por esta área faz com que para mim seja impossível não visualizar um projecto sem componente sonora.

Em termos de implementação, criei um simples sound manager que gere os sound effects a tocar e simplifica os pedidos de play, de forma a não ter de "encher" muitos objectos do jogo com AudioSources locais para tocar os efeitos. Visto que neste caso os sons não seriam prováveis de tocar simultaneamente, esta abordagem é suficiente. A música, como não existiria nenhuma situação onde teria de ser manipulada, é apenas iniciada no início da aplicação e deixada em loop.