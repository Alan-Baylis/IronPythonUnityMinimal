import UnityEngine as unity

class Move(object): 

	def Awake(self, this):
		self.direction = 1
		self.x = -4.0

	def Update(self, this):
		if self.x >= 4.0:
			self.direction = -1
		elif self.x < -4.0:
			self.direction = 1
		self.x += .2 * self.direction * (unity.Time.deltaTime * 100)
		this.transform.position = unity.Vector3(self.x, this.transform.position.y, this.transform.position.z)