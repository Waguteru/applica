import math

# зададим значения переменных x, y, z
x = 0.1722
y = 6.33
z = 3.25 * 10**-4

# вычислим модуль разности x и y
absolute_difference = abs(x - y)

# вычислим арктангенс и арккосинус
arctg_x = math.atan(x)
arccos_x = math.acos(x)

# вычислим числитель формулы
numerator = (x + 3 * absolute_difference + x**2)

# вычислим знаменатель формулы
denominator = (absolute_difference * z + x**2)

# проверим, чтобы знаменатель не был равен нулю
if denominator != 0:
    # вычислим значение s
    s = 5 * arctg_x - (1/4) * arccos_x * (numerator / denominator)
    print(s)
else:
    print("Знаменатель равен нулю, формула не может быть вычислена.")