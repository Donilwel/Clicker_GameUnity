# Unity Кликкер
Создать перечисление GameResource (Humans, Food, Wood, Stone, Gold)

Создать класс ResourceBank, отвечающий за ресурсы в игре. 
Поля:
Словарь c ключами - GameResource и значениями ObservableInt.
Методы:
ChangeResource (GameResource r, int v) - увеличивает значение ресурса r из словаря на v;
GetResource (GameResource r) - возвращает ObservableInt из словаря, соответствующий ресурсу r.


ResourceBank.cs

Создать компонент GameManager.
Методы:
Awake - добавляет в ResourceBank начальные ресурсы (10 Humans, 5 Food и 5 Wood).

Создать компонент ResourceVisual. 
Этот компонент будет отвечать за отображение текущего количества одного из ресурсов ResourceBank.
Поля:
GameResource;
TextMeshProUGUI Text.

Используя ResourceVisual создать на сцене счётчики для каждого типа ресурса (Humans, Food, Wood, Stone, Gold).




(6-7 баллов)
Создать компонент ProductionBuilding. 
Добавить кнопку под счетчик каждого ресурса. Добавить к ней компонент ProductionBuilding. При нажатии на кнопку соответствующий ресурс должен увеличиваться на 1, значение счетчика обновляться в соответствии с новым значением.


Пример сцены

Добавить в ProductionBuilding поле ProductionTime.
Модифицировать ProductionBuilding так, чтобы при нажатии кнопки запускалась Coroutine, которая при прошествии ProductionTime увеличивала соответствующий ресурс на 1. 

Добавить к каждой кнопке слайдер, который будет отображать прогресс выполнения coroutine. Кнопка должна становиться неактивной при запуске coroutine и активной при окончании.



(8-10 баллов)
Добавить в GameResource уровни производства: HumansProdLvl, FoodProdLvl, WoodProdLvl, StoneProdLvl и GoldProdLvl.

Добавить на сцену панель магазина, где при нажатии на соответствующие кнопки можно увеличить уровень производства каждого ресурса. 

Модифицировать ProductionBuilding так, чтобы скорость производства ресурса зависела от уровня производства, например WoodProdTime = ProductionTime*(1-WoodProdLvl.value/100)
