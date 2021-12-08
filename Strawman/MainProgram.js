// A robot task
void task()
{
    var UR;
    var DM1;
    
    DM1 = "";
    robot_task = "movement1";
    robot_running = true
    send(DM1, "+");
    send(UR,"(1,0,0,0)");

    while(robot_running)
    {
        sleep(100);
    }

    // Already done
    while(DM1="")
    {
        sleep(100);
    }
}