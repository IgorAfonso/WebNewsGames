package newsHandler

import (
	"fmt"

	"github.com/gin-gonic/gin"
)

func GetNews(ctx *gin.Context) {
	fmt.Println("FUNCIONOU")
}