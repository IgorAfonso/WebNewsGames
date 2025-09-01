package router

import (
	"fmt"

	"github.com/gin-gonic/gin"
)

func newsRoutes(router *gin.Engine) {
	basePath := "/api/v1"
	
	v1 := router.Group(basePath)
	{
		v1.GET("/news", func(ctx *gin.Context) {
			fmt.Println("FUNCIONOU")
		})
		v1.GET("/listnews", func(ctx *gin.Context) {
			fmt.Println("FUNCIONOU")
		})
		v1.POST("/news", func(ctx *gin.Context) {
			fmt.Println("FUNCIONOU")
		})
		v1.DELETE("/news", func(ctx *gin.Context) {
			fmt.Println("FUNCIONOU")
		})
		v1.PATCH("/news", func(ctx *gin.Context) {
			fmt.Println("FUNCIONOU")
		})
	}
}