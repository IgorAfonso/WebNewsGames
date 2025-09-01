package router

import "github.com/gin-gonic/gin"

func Initialize() {
	router := gin.Default()
	newsRoutes(router)
	router.Run(":8080")
}