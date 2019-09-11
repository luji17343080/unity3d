# 离散仿真引擎基础
## 问题1：简答题【建议做】
- 解释 游戏对象（GameObjects） 和 资源（Assets）的区别与联系。  
- 下载几个游戏案例，分别总结资源、对象组织的结构（指资源的目录组织结构与游戏对象树的层次结构）  
- 编写一个代码，使用 debug 语句来验证 MonoBehaviour 基本行为或事件触发的条件   
   - 基本行为包括 Awake() Start() Update() FixedUpdate() LateUpdate()  
   - 常用事件包括 OnGUI() OnDisable() OnEnable()  
- 查找脚本手册，了解 GameObject，Transform，Component 对象  
   - 分别翻译官方对三个对象的描述（Description）  
   - 描述下图中 table 对象（实体）的属性、table 的 Transform 的属性、 table 的部件   
      - 本题目要求是把可视化图形编程界面与 Unity API 对应起来，当你在 Inspector 面板上每一个内容，应该知道对应 API。  
      - 例如：table 的对象是 GameObject，第一个选择框是 activeSelf 属性。  
   - 用UML图描述三者的关系（请使用UMLet14.1.1stand-alone版本出图）  
- 整理相关学习资料，编写简单代码验证以下技术的实现：  
   - 查找对象  
   - 添加子对象  
   - 遍历对象树  
   - 清除所有子对象  
- 资源预设（Prefabs）与 对象克隆 (clone)  
   - 预设（Prefabs）有什么好处？  
   - 预设与对象克隆 (clone or copy or Instantiate of Unity Object) 关系？  
   - 制作 table 预制，写一段代码将 table 预制资源实例化成游戏对象  
  
## 问题2：编程实践，小游戏  
- 游戏内容： 井字棋或贷款计算器或简单计算器等等  
- 技术限制： 仅允许使用IMGUI构建UI  
- 作业目的：  
   - 了解 OnGUI() 事件，提升 debug 能力  
   - 提升阅读 API 文档能力  
  
## 问题3：思考题【选做】  
- 微软 XNA 引擎的 Game 对象屏蔽了游戏循环的细节，并使用一组虚方法让继承者完成它们，我们称这种设计为“模板方法模式”。  
   - 为什么是“模板方法”模式而不是“策略模式”呢？
- 将游戏对象组成树型结构，每个节点都是游戏对象（或数）。  
   - 尝试解释组合模式（Composite Pattern / 一种设计模式）。  
   - 使用 BroadcastMessage() 方法，向子对象发送消息。你能写出 BroadcastMessage() 的伪代码吗?  
- 一个游戏对象用许多部件描述不同方面的特征。我们设计坦克（Tank）游戏对象不是继承于GameObject对象，而是 GameObject 添加一组行为部件（Component）。  
   - 这是什么设计模式？  
   - 为什么不用继承设计特殊的游戏对象？  
