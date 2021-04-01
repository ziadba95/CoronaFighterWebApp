function ReservEdit(e){
 const status = e.parentNode.parentNode.childNodes;
 const cost =status[11].childNodes;
 switch(e.textContent){
   case "Decline" :
     if(status[9].textContent === "Done"){
       alert("the Maintenance is already done!");
     }
     else{
     status[17].textContent="Canceled";
     status[17].style.color="red";
     cost[1].classList.add("d-block");
     cost[1].classList.remove("d-none");
     cost[3].classList.add("d-none");
     cost[1].textContent="-";
   }
     break;
   case "Accept" :
      if(status[9].textContent === "Done"){
       alert("the Maintenance is already done!");
     }
     else{
     status[17].textContent="Accepted";
     status[17].style.color="green";
     cost[1].classList.add("d-block");
     cost[1].classList.remove("d-none");
     cost[3].classList.add("d-none");
     cost[1].textContent="-";
   }
     break;
          
   default:
     break;
 }
}