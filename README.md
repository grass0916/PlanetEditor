# PlanetEditor
台科內部訓練，欲接受訓練的同學請將本程式移植到C#。
## 思維訓練題
* 什麼是Class
* 什麼是Constructor
* 什麼是Destructor
* 什麼是Interface
* 什麼是Polymorphism 我在哪使用了Polymorphism
* [什麼是template](https://github.com/bachelorwhc/PlanetEditor/blob/master/creature.h#L20)
* [`Planet::Planet(const Planet & src)`將會產生什麼問題](https://github.com/bachelorwhc/PlanetEditor/blob/master/planet.cpp#L7)
* `std::shared_ptr`是什麼
* 如果忘記釋放記憶體會發生什麼事 C#會發生相同的事嗎

## Commands
### cp \<name> \<x> \<y> \<z> \<radius>
* 新增名為\<name> 坐標為\(\<x>,\<y>,\<z>\)半徑為\<radius>的星球。

### up
* 更新星球物件並顯示資訊

### ro \<id>
* 移除ID為\<id>的物件

### ac \<type> \<name>
* 新增\<type>種類並名為\<name>的生物
