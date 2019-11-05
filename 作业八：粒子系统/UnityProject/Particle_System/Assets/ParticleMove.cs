using UnityEngine;
using System.Collections;

public class ParticleMove : MonoBehaviour {
	public class ParticleAttr { //粒子属性
		public float radius = 0.0f; //粒子旋转的半径
		public float angle = 0.0f; //粒子的角度
		public ParticleAttr(float r, float a) {
			radius = r;
			angle = a;
		}
	}

	public ParticleSystem ParticleRing; //创建一个粒子环系统
	private ParticleSystem.Particle[] particles; //粒子数组
	private ParticleAttr[] particleAttr; //粒子属性数组
	public int particleNum = 30000; //粒子的数目
	public float minRadius = 0f; //粒子旋转的最小半径
	public float maxRadius = 5.0f; //粒子旋转的最大半径
	public int layerNum = 2; //粒子的层数
	public float speed = 0.5f; //粒子旋转的速度

	void Start() {
		//为粒子数组和粒子属性数组分配空间，大小为粒子数目
		particleAttr = new ParticleAttr[particleNum];
		particles = new ParticleSystem.Particle[particleNum];

		ParticleRing.maxParticles = particleNum; //最大粒子数
		ParticleRing.Emit(particleNum); //动态生成粒子
		ParticleRing.GetParticles(particles); //获得粒子数组中的粒子
		for (int i = 0; i < particleNum; i++) {
			float randomAngle = Random.Range(0.0f, 360.0f); //产生随机角度
			float randomRadius = Random.Range(minRadius, maxRadius); //产生随机半径
			//粒子属性设置
			particleAttr[i] = new ParticleAttr(randomRadius, randomAngle);
			particles[i].position = new Vector3(randomRadius * Mathf.Cos(randomAngle), randomRadius * Mathf.Sin(randomAngle), 0.0f);
		}
		//设置粒子
		ParticleRing.SetParticles(particles, particleNum);
	}


	void Update() { //设置粒子系统的旋转运动
		//根据粒子的层数设置为几部分，最外层顺时针旋转，往里方向交替
		for (int i = 0; i < particleNum; i++) {
			if (i % 2 == 0) particleAttr[i].angle += (i % layerNum + 1) * speed;
			else particleAttr[i].angle -= (i % layerNum + 1) * speed;

			//根据新的角度重新设置位置
			particleAttr[i].angle = particleAttr[i].angle % 360;
			float rad = particleAttr[i].angle / 180 * Mathf.PI;
			particles[i].position = new Vector3(particleAttr[i].radius * Mathf.Cos(rad), particleAttr[i].radius * Mathf.Sin(rad), 0f);
		}
		ParticleRing.SetParticles(particles, particleNum);
	}
}