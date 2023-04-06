namespace ConsoleApp1;

public class BmiDeterminator
{
    public BmiClassification DetermineBmi(double bmi) => bmi switch
    {
        < 18.5 => BmiClassification.Underweight,
        < 24.5 => BmiClassification.Normal,
        < 29.9 => BmiClassification.Overweight,
        < 34.9 => BmiClassification.Obesity,
        _ => BmiClassification.ExtremeObesity
    };
}