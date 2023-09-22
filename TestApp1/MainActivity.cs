using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace TestApp1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView resultTextView;
        private string currentInput = "";
        private double currentNumber = 0;
        private string operation = "";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            resultTextView = FindViewById<TextView>(Resource.Id.myTextView);
            resultTextView.Text = "Введите число";
            Button button0 = FindViewById<Button>(Resource.Id.button0);
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button button7 = FindViewById<Button>(Resource.Id.button7);
            Button button8 = FindViewById<Button>(Resource.Id.button8);
            Button button9 = FindViewById<Button>(Resource.Id.button9);
            Button buttonPlus = FindViewById<Button>(Resource.Id.buttonPlus);
            Button buttonMinus = FindViewById<Button>(Resource.Id.buttonMinus);
            Button buttonMultiply = FindViewById<Button>(Resource.Id.buttonMultiply);
            Button buttonDiv = FindViewById<Button>(Resource.Id.buttonDiv);
            Button buttonEquals = FindViewById<Button>(Resource.Id.buttonEquals);
            Button buttonClear = FindViewById<Button>(Resource.Id.buttonClear);
            Button buttonPercent = FindViewById<Button>(Resource.Id.buttonPercent);
            Button buttonMod = FindViewById<Button>(Resource.Id.buttonMod);
            Button buttonSqrt = FindViewById<Button>(Resource.Id.buttonSqrt);

            button0.Click += Button_Click;
            button1.Click += Button_Click;
            button2.Click += Button_Click;
            button3.Click += Button_Click;
            button4.Click += Button_Click;
            button5.Click += Button_Click;
            button6.Click += Button_Click;
            button7.Click += Button_Click;
            button8.Click += Button_Click;
            button9.Click += Button_Click;
            buttonPlus.Click += OperationButton_Click;
            buttonMinus.Click += OperationButton_Click;
            buttonMultiply.Click += OperationButton_Click;
            buttonDiv.Click += OperationButton_Click;
            buttonEquals.Click += EqualsButton_Click;
            buttonClear.Click += ClearButton_Click;
            buttonPercent.Click += OperationButton_Click;
            buttonMod.Click += OperationButton_Click;
            buttonSqrt.Click += SqrtButton_Click;
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            resultTextView.Text = currentInput;
        }

        private void OperationButton_Click(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            double.TryParse(currentInput, out currentNumber);
            operation = button.Text;
            currentInput = "";
            resultTextView.Text = "";
        }

        private void EqualsButton_Click(object sender, System.EventArgs e)
        {
            double secondNumber;
            double.TryParse(currentInput, out secondNumber);

            switch (operation)
            {
                case "+":
                    currentNumber += secondNumber;
                    break;
                case "-":
                    currentNumber -= secondNumber;
                    break;
                case "*":
                    currentNumber *= secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                    {
                        currentNumber /= secondNumber;
                    }
                    else
                    {
                        resultTextView.Text = "Error";
                        return;
                    }
                    break;
                case "%":
                    currentNumber = (secondNumber * currentNumber) / 100.0;
                    break;
                case "Mod":
                    if (secondNumber != 0)
                    {
                        currentNumber = currentNumber % secondNumber;
                    }
                    else
                    {
                        resultTextView.Text = "Error";
                        return;
                    }
                    break;
                default:
                    resultTextView.Text = "Error";
                    return;
            }

            resultTextView.Text = currentNumber.ToString();
            currentInput = currentNumber.ToString();
        }


        private void ClearButton_Click(object sender, System.EventArgs e)
        {
            currentInput = "";
            currentNumber = 0;
            operation = "";
            resultTextView.Text = "";
        }

        private void SqrtButton_Click(object sender, System.EventArgs e)
        {
            double.TryParse(currentInput, out currentNumber);
            if (currentNumber >= 0)
            {
                double result = System.Math.Sqrt(currentNumber);
                resultTextView.Text = result.ToString();
                currentInput = result.ToString();
            }
            else
            {
                resultTextView.Text = "Error";
            }
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}