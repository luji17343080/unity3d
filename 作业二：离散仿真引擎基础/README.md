# 作业二：离散仿真引擎基础
## 问题1：简答题【建议做】
- 解释游戏对象（GameObjects）和资源（Assets）的区别与联系。
  >  

- 下载几个游戏案例，分别总结资源、对象组织的结构（指资源的目录组织结构与游戏对象树的层次结构）  
- 编写一个代码，使用 debug 语句来验证 MonoBehaviour 基本行为或事件触发的条件   
   - 基本行为包括 Awake() Start() Update() FixedUpdate() LateUpdate()  
   - 常用事件包括 OnGUI() OnDisable() OnEnable()  
  
   代码如下：
   ```  
   using System.Collections;
   using System.Collections.Generic;
   using UnityEngine;  
   public class DebugTest : MonoBehaviour {
      void Awake() {
         Debug.Log ("Awake!");
      }

      void Start() {
         Debug.Log ("Start!");
      }

      void Update() {
         Debug.Log ("Update!");
      }

      void FixeUpdate() {
         Debug.Log ("FixeUpdate!");
      }

      void LateUpdate() {
         Debug.Log ("LateUpdate!");
      }

      void OnGUI() {
         Debug.Log ("OnGUI!");	
      }

      void OnDisable() {
         Debug.Log ("OnDisable");
      }

      void OnEnable() {
         Debug.Log ("OnEnable");
      }
   }  
   ```  
  
   将上述代码附给一个对象然后运行，在控制台会得到如下内容：  
  
   ![](images/console.png)  
  
   > 可以看出，基本行为中Awake函数是在对象执行脚本之初被调用，且在整个生命周期内只被调用一次；然后调用OnEnable函数激活对象，且激活之后不再调用；接着在第一次进入游戏时调用Start函数；然后在Start函数调用完之后，调用Update函数（循环调用）；然后在所有的Update循环调用里面，当Update调用完之后会调用LateUpdate函数；最后OnGUI函数会在游戏循环的渲染过程中调用，而FixUpdate函数是在每个游戏循环中由物理引擎调用。  
     
- 查找脚本手册，了解GameObject，Transform，Component对象  
   - 分别翻译官方对三个对象的描述（Description）  
   > **GameObject**：游戏对象，是Unity场景里面所有实体的基类。  
   > **Transform**：变换，物体的位置、旋转和缩放。场景中的每一个物体都有一个Transform，用于储存并操控物体的位置、旋转和缩放。每一个Transform可以有一个父级，允许你分层次应用位置、旋转和缩放。可以在Hierarchy面板查看层次关系。他们也支持计数器（enumerator），因此你可以使用循环遍历子物体。  
   > **Component**：组件，一切附加到游戏物体的基类。  

   - 描述下图中table对象（实体）的属性、table的Transform的属性、table 的部件   
      - 本题目要求是把可视化图形编程界面与 Unity API对应起来，当你在 Inspector 面板上每一个内容，应该知道对应 API。  
      - 例如：table 的对象是 GameObject，第一个选择框是 activeSelf 属性。  
   - 用UML图描述三者的关系（请使用UMLet14.1.1stand-alone版本出图）  
     
      ![](images/UML.png)  
     

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
