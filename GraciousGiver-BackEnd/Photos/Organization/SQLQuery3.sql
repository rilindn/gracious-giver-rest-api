ALTER TABLE Request
ADD CONSTRAINT FK_UsersProdd
FOREIGN KEY (ReceiverId) REFERENCES Users(UserId);

ALTER TABLE [dbo].ProductPhotos  
WITH CHECK ADD  CONSTRAINT [FK_Product_PPhotos] FOREIGN KEY([Product])
REFERENCES [dbo].[Product] ([ProductId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].Request  
WITH CHECK ADD  CONSTRAINT [FK_Request_Users] FOREIGN KEY([ReceiverId])
REFERENCES [dbo].[Users] ([UserId])

ALTER TABLE [dbo].OfferProduct  
WITH CHECK ADD  CONSTRAINT [FK_OfferProduct_Users] FOREIGN KEY([ProductProviderId])
REFERENCES [dbo].[Users] ([UserId])

ALTER TABLE [dbo].OfferProduct  
WITH CHECK ADD  CONSTRAINT [FK_OfferProduct_UsersR] FOREIGN KEY([ReceiverId])
REFERENCES [dbo].[Users] ([UserId])



ALTER TABLE OfferedProductResponse  
ADD OfferProductId INT UNIQUE NOT NULL

ALTER TABLE [dbo].OfferedProductResponse  
WITH CHECK ADD  CONSTRAINT [FK_OfferProductRes_OfferProduct] FOREIGN KEY([OfferProductId])
REFERENCES [dbo].[OfferProduct] ([OfferProductId])

ALTER TABLE [dbo].Bookmark
WITH CHECK ADD  CONSTRAINT [FK_Bookmark_ProdUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])

ALTER TABLE [dbo].Bookmark
WITH CHECK ADD  CONSTRAINT [FK_Bookmark_ProdUser2] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])

ALTER TABLE [dbo].OfferProduct  
WITH CHECK ADD  CONSTRAINT [FK_OfferProduct_RequestR] FOREIGN KEY([RequestId])
REFERENCES [dbo].[Request] ([RequesttId])

select UserId from Product_Request 
WHERE UserId NOT IN
(SELECT UserId from Users)

ALTER TABLE [dbo].Product_Request  
WITH CHECK ADD  CONSTRAINT [FK_Product_Request_ProdR] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])