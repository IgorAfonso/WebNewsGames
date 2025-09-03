package schema

import (
	"time"

	"github.com/google/uuid"
)

type News struct {
	ID uuid.UUID
	Title string
	CreateDate time.Time
	UpdateDate time.Time
	DeleteDate time.Time
	FirstContent string
	SecondContent string
	ThirdContent string
}