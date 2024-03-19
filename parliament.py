## Rules for a accepting political party into Czech parliament(and working with the results of the election from 2021):
## Every single party with 5% and more votes is becoming part of parliament
## Every double coalition with 8% and more votes is becoming part of parliament
## Every multi coalition with 11% and more votes is becoming part of parliament
## Parties not eligible are stored in the leftovers list
## Parties elected are stored in the parliament list
## This excercise doesn't count with the independent candidates or eligibility for compensation when party reaches over 1,5%
## This excercise doesn't count with the option that none of the candidates is eligible for parliament


percentage = [27.79, 27.12, 15.62, 9.56, 4.68, 4.65, 5.1]
coalition = ["multi", "single", "double", "single", "single", "single", "multi"]
parties = ["SPOLU", "ANO", "PirStan", "SPD", "Prisaha", "CSSD", "Imaginary"]
parliament = []
leftovers = []

for i in range(len(percentage)):
    x = percentage[i]
    y = coalition[i]
    z = parties[i]
    if x < 5:
        leftovers.append((z, x, y))
    elif y == "double" and x < 8:
        leftovers.append((z, x, y))
    elif y == "multi" and x < 11:
        leftovers.append((z, x, y))
    else:
        parliament.append((z, x, y))

print(parliament)
print(leftovers)

