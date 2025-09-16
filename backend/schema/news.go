package schema

import (
	"github.com/google/uuid"
	"gorm.io/gorm"
)

type News struct {
	gorm.Model
	ID uuid.UUID
	Title string
	FirstContent string
	SecondContent string
	ThirdContent string
}