function modifyObject(obj){

    if(obj.dizziness === true){

        obj.levelOfHydrated += obj.weight * 0.1 * obj.experience;
        obj.dizziness = false;
    }

    return obj;

}

modifyObject({ weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true }
  
  );