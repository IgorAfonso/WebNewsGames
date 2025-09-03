package main

import (
	"fmt"

	"main.go/config"
	"main.go/router"
)

//@title WebNewsAPI
func main(){

  //Initialzie Configs
  err := config.Init()
  if(err != nil){
		fmt.Errorf("config initializarion error: %v", err)
		return
	}

  router.Initialize()
}
