// UR
void prog1()
{
    // DoPolyscript

    send(
        "{" +
        "robot_running = false;" +
        "}");
    }
}

void prog2()
{
    // DoPolyscript

    send(
        "{" +
        "robot_running = false;" +
        "}");
    }
}

// Dataman
var ID="DM1"
var sequence = 0;
void trigger()
{
    sequence++;

    // Read barcode
    var value = "12345";

    send(
        "{" +
        ID + "_sequence = " + sequence + ";" +
        ID + "_value = " + value + ";" +
        "}");

}
