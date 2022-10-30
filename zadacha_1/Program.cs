//     Есть число N. Скольно групп M, можно получить при разбиении всех чисел на группы, так чтобы в одной группе все числа были взаимно просты.


int n = InputNumbers("Введите число N: ");

int[] tempArray = CreateArray(n);
CreateRows(tempArray);

void CreateRows(int[] arrayCheck)
{
  int[] arrayTemp = new int[arrayCheck.Length];
  int m = 1;
  int count = 0;
  int tempNumber = 0;
  int tempNumber2 = 0;
  int tempSwitch = 0;
  
  for (int i = 0; i < arrayCheck.Length; i++)
  {
    Array.Clear(arrayTemp);
    count = 0;
    if (arrayCheck[i] != 0)
    {
      arrayTemp[count] = arrayCheck[i];
      tempNumber2 = arrayCheck[i];

      for (int j = i; j < arrayCheck.Length; j++)
      {
        if (arrayCheck[j] % tempNumber2 != 0 || arrayCheck[j] / tempNumber2 == 1)
        {
          tempSwitch = 0;
          tempNumber = arrayCheck[j];
          for (int k = 0; k < count; k++)
          {
            if (tempNumber % arrayTemp[k] == 0) tempSwitch++;
          }
          if (tempSwitch == 0)
          {
            arrayTemp[count] = arrayCheck[j];
            count++;
            arrayCheck[j] = 0;
          }
        }
      }
      Console.WriteLine($"Группа {m++}: {PrintIntArray(arrayTemp)}");
    }
  }
}

int InputNumbers(string input)
{
  Console.Write(input);
  int output = Convert.ToInt32(Console.ReadLine());
  return output;
}

int[] CreateArray(int n)
{
  int[] temp = new int[n];
  for (int i = 0; i < temp.GetLength(0); i++)
  {
    temp[i] = i + 1;
  }
  return temp;
}

string PrintIntArray(int[] array)
{
  string result = string.Empty;
  for (int i = 0; i < array.Length; i++)
  {
    if (array[i] != 0) result += $"{array[i],1} ";
  }
  return result;
}