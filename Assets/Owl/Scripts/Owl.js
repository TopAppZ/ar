#pragma strict
var owl : Animator;


function Start () {

}

function Update () {
if(Input.GetKey(KeyCode.Alpha1)){
owl.SetBool("Idle",true);
owl.SetBool("Look",false);
owl.SetBool("Eat",false);
}
if(Input.GetKey(KeyCode.Alpha2)){
owl.SetBool("Look",true);
owl.SetBool("Idle",false);
owl.SetBool("Eat",false);
}
if(Input.GetKey(KeyCode.Alpha3)){
owl.SetBool("Walk",true);
owl.SetBool("Look",false);
}
if(Input.GetKey(KeyCode.Alpha4)){
owl.SetBool("Takeoff",true);
owl.SetBool("Walk",false);
fly();
}
if(Input.GetKey(KeyCode.Alpha5)){
owl.SetBool("Fly",true);
owl.SetBool("Glide",false);
}
if(Input.GetKey(KeyCode.Alpha6)){
owl.SetBool("Glide",true);
owl.SetBool("Fly",false);
}
if(Input.GetKey(KeyCode.Alpha7)){
owl.SetBool("Attack",true);
owl.SetBool("Fly",false);
fly2();
}
if(Input.GetKey(KeyCode.Alpha8)){
owl.SetBool("Landing",true);
owl.SetBool("Fly",false);
idle();
}
if(Input.GetKey(KeyCode.Alpha9)){
owl.SetBool("Eat",true);
owl.SetBool("Idle",false);
owl.SetBool("Look",false);
}
if(Input.GetKey(KeyCode.Alpha0)){
owl.SetBool("Die",true);
owl.SetBool("Idle",false);
}
}

function fly(){
yield WaitForSeconds(1.2);
owl.SetBool("Takeoff",false);
owl.SetBool("Fly",true);
}
function fly2(){
yield WaitForSeconds(2.8);
owl.SetBool("Attack",false);
owl.SetBool("Fly",true);
}
function idle(){
yield WaitForSeconds(1);
owl.SetBool("Landing",false);
owl.SetBool("Idle",true);
}