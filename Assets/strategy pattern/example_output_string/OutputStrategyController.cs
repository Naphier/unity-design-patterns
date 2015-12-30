using UnityEngine;
using System.Collections;
using Assets.strategy_pattern.example_output_string;

public class OutputStrategyController : MonoBehaviour
{
    public string input = "This is some arbitrary input string";

    void Start()
    {
        OutputContext context = new OutputContext(new CSVOutput(' '));
        Debug.Log("This is the CSV output:\n" + context.GetOutput(input));

        //Easily change the context!
        context = new OutputContext(new EncryptedOutput());
        Debug.Log("This is the encrypted output:\n" + context.GetOutput(input));

    }
}
