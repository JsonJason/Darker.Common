using System;

namespace Clarity
{
    /// <summary>
    ///     A Meter value from 0 -> Maximum.
    ///     Can be increased and Decreased, Can be depleted
    ///     Health etc
    /// </summary>
    public class Meter
    {
        private int _maximum;
        private int _value;

        public Meter(int maximum)
        {
            Maximum = maximum;
            Value = Maximum;
        }

        public int Maximum
        {
            get => _maximum;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value),
                        $"Meter maximum value must be greater than zero. Cannot set to: {value}");
                _maximum = value;
                if (value < Value)
                    Value = Maximum;
            }
        }

        public int Value
        {
            get => _value;
            set
            {
                if (value > Maximum)
                    throw new ArgumentOutOfRangeException(nameof(value),
                        $"Maximum Value is {Maximum}. Cannot set to: {value}");
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value),
                        $"Meter value must be a positive number. Cannot set to: {value}");
                var args = new MeterEventArgs
                {
                    Amount = Math.Abs(_value - value),
                    Direction = value.CompareTo(_value)
                };
                _value = value;

                OnChanged(args);
                if (_value == 0) OnDepleted();
            }
        }

        public float PercentageFilled => (float) Value / Maximum * 100;

        public int Decrease(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(
                    $"Meter decrease amount must be a positive number. Cannot decrease by {amount}.");
            if (amount > Value)
            {
                var remainder = amount - Value;
                Value = 0;
                return remainder;
            }
            Value -= amount;
            return 0;
        }

        public int Increase(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(
                    $"Meter increase amount must be a positive number. Cannot increase by {amount}.");

            var afterIncrease = Value + amount;

            if (afterIncrease >= Maximum)
            {
                Value = Maximum;
                OnRefilled();
                return afterIncrease - Maximum;
            }
            Value += amount;
            return 0;
        }

        public int Refill()
        {
            var required = Maximum - Value;
            Increase(required);
            return required;
        }

        public int Deplete()
        {
            var amountToDeplete = Value;
            Decrease(amountToDeplete);
            return amountToDeplete;
        }

        public int FillToPercent(float percent)
        {
            if (percent < 0)
                throw new ArgumentOutOfRangeException(nameof(percent),
                    $"Percent to fill to must be a positive number, cannot fill to {percent}%");
            if (percent > 100)
                throw new ArgumentOutOfRangeException(nameof(percent),
                    $"Cannot fill Meter over 100%. Cannot fill to {percent}% ");
            var desiredValue = (int) ((float) Maximum / 100 * percent);

            if (desiredValue > Value)
            {
                var increase = desiredValue - Value;
                Increase(increase);
                return increase;
            }

            var decrease = Value - desiredValue;
            Decrease(decrease);
            return -decrease;
        }

        public void SetMaximumToPercent(int percent)
        {
            if (percent < 0)
                throw new ArgumentOutOfRangeException(nameof(percent),
                    $"Cannot set maximum to negative percent, cannot set to {percent}%");

            var desiredValue = (int) ((float) Maximum / 100 * percent);
            Maximum = desiredValue;
        }

        public event EventHandler Refilled;

        protected virtual void OnRefilled()
        {
            Refilled?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Depleted;

        protected virtual void OnDepleted()
        {
            Depleted?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler<MeterEventArgs> Changed;


        protected virtual void OnChanged(MeterEventArgs e)
        {
            Changed?.Invoke(this, e);
        }
    }

    public class MeterEventArgs : EventArgs
    {
        public int Amount { get; set; }
        public int Direction { get; set; }
    }
}