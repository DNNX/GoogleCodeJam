SOURCE = 'CandySplitting'
TARGET = 'Magicka'

require 'uuidtools'
require 'fileutils'

files = {
    "#{SOURCE}/Properties/AssemblyInfo.cs" => "#{TARGET}/Properties/AssemblyInfo.cs",
    "#{SOURCE}/#{SOURCE}.cs"               => "#{TARGET}/#{TARGET}.cs",
    "#{SOURCE}/#{SOURCE}Test.cs"           => "#{TARGET}/#{TARGET}Test.cs",
    "#{SOURCE}/#{SOURCE}.csproj"           => "#{TARGET}/#{TARGET}.csproj"
}

FileUtils.rm_rf TARGET 
Dir::mkdir TARGET
Dir::mkdir "#{TARGET}/Properties"

files.each do |source, target|
    FileUtils.cp source, target
end

files.values.each do |target|
    text = File.read(target)
    text.gsub!(SOURCE, TARGET)
    File.open(target, 'wb') { |f| f.write(text) }
end

text = File.read("#{TARGET}/#{TARGET}.csproj")
source_guid = text.match(/<ProjectGuid>{(.*)}<\/ProjectGuid>/)[1]
target_guid = UUIDTools::UUID.random_create.to_s.upcase

text.gsub!(source_guid, target_guid)
File.open("#{TARGET}/#{TARGET}.csproj", 'wb') { |f| f.write(text) }
