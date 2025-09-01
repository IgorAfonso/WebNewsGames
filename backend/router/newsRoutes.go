package router

import (
	"github.com/gin-gonic/gin"
	handler "main.go/handler/newshandlers"
)

func newsRoutes(router *gin.Engine) {
	basePath := "/api/v1"
	
	v1 := router.Group(basePath)
	{
		v1.GET("/news", handler.GetNews)
		v1.GET("/listnews", handler.ListNews)
		v1.POST("/news", handler.CreateNews)
		v1.DELETE("/news", handler.DeleteNews)
		v1.PATCH("/news", handler.UpdateNews)
	}
}